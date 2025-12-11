import { Component } from '@angular/core';
import { Chart, ChartOptions } from 'chart.js/auto';
import { Transactions } from '../../services/transactions';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

/**
 * The TopSellingChart component displays a bar chart of the top-selling items
 * across all supermarkets managed by the logged-in user.
 */
@Component({
  selector: 'app-top-selling-chart',
  templateUrl: './top-selling-chart.html',
  styleUrls: ['./top-selling-chart.css'],
  imports: [FormsModule]
})
export class TopSellingChart {

  /** Whether data is currently being loaded. */
  loading = true;

  /** Error message displayed when chart data cannot be loaded. */
  errorMessage: string | null = null;

  /** The Chart.js instance used to render the bar chart. */
  chart: Chart | null = null;

  /** The number of top-selling items to display. */
  limit: number = 5;

  /** The total number of available top-selling items. */
  overallTotal: number = 5;

  /** List of supermarket names associated with the top-selling items. */
  supermarketNames: string[] = [];

  /**
   * The constructor for the TopSellingChart component.
   * @param transactionsService Service responsible for fetching transaction statistics.
   * @param router Used to navigate between application routes.
   */
  constructor(
    private transactionsService: Transactions,
    private router: Router
  ) {}

  /**
   * Loads the initial top-selling chart when the component is rendered.
   */
  ngOnInit(): void {
    this.loadChart();
  }

  /**
   * Navigates the user back to the Home component.
   */
  home(): void {
    this.router.navigate(['/home']);
  }

  /**
   * Adjusts the number of top-selling items displayed on the chart,
   * ensuring the value remains within valid limits.
   */
  applyLimit(): void {
    if (this.limit < 1) this.limit = 1;
    if (this.limit > this.overallTotal) this.limit = this.overallTotal;
    this.loadChart();
  }

  /**
   * Loads the chart data from the Transactions service and renders a bar chart
   * of the top-selling items.
   */
  loadChart(): void {
    this.loading = true;

    this.transactionsService.getTopSellingItems(this.limit).subscribe({
      next: (response: any) => {
        this.loading = false;

        const data = response.results;
        this.overallTotal = response.overall_total;

        const labels = data.map((item: any) => item.item_name);
        const values = data.map((item: any) => item.total_sold);

        this.supermarketNames = data.map(
          (item: any) => item.supermarket_name || 'Unknown supermarket'
        );

        if (this.chart) this.chart.destroy();

        this.chart = new Chart('topSellingChart', {
          type: 'bar',
          data: {
            labels,
            datasets: [
              {
                label: 'Units Sold',
                data: values,
                backgroundColor: this.generateColours(values.length),
                borderRadius: 8,
                borderSkipped: false
              }
            ]
          },
          options: this.chartOptions(labels.length),
        });
      },
      error: (err) => {
        this.loading = false;
        console.error(err);
        this.errorMessage = 'Failed to load top-selling chart.';
      }
    });
  }

  /**
   * Generates an array of unique HSL colour values for chart bars.
   * @param count The number of colours to generate.
   */
  generateColours(count: number): string[] {
    return Array.from({ length: count }).map((_, i) =>
      `hsl(${(i * 55) % 360}, 70%, 55%)`
    );
  }

  /**
   * Defines the configuration options for the Chart.js bar chart.
   * @param count The number of bars to display.
   */
  chartOptions(count: number): ChartOptions<'bar'> {
    return {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { display: false },
        tooltip: {
          callbacks: {
            label: (context: any) => {
              const index = context.dataIndex;
              const units = context.parsed.y;
              const market = this.supermarketNames[index];
              return `${units} sold at ${market}`;
            }
          }
        }
      },
      scales: {
        x: {
          ticks: { font: { size: 14 } }
        },
        y: {
          beginAtZero: true,
          ticks: { font: { size: 14 } },
          grid: { color: 'rgba(0,0,0,0.1)' }
        }
      }
    };
  }
}
