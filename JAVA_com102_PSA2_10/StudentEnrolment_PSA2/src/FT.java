/*
 This is the Full Time class which is a child class of the Student Class. This class is used whenever a new Full Time 
 student is registred as the fee cost differentiates regading their Sutdy mode. 
 */

/**
 *
 * @author b00884706
 */
public class FT extends Student {
    
   // private double fee;
    public FT(String newName, String newDob, char newGender, String newMode, String newYear, int newModules)
    {
        
        super(newName, newDob, newGender, newMode, newYear, newModules);
        
      
    }
    
   @Override
    public double computingFee()
    {
        if(!"3".equals(getYear()))
        {
           setFees(5000);
        }
        else
        {
           setFees(2500);
        }   
        return getFees();
    } 
}
