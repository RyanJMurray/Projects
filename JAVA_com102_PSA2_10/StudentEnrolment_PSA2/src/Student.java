/*
//RYANS 
This is the Student Class. In this class the main constructor is made where the new student values are passed through and assigned using sets and constructors,
and in addition the student details can be displayed using the gets. 
 */

/**
 *
 * @author b00884706
 */

import java.util.Scanner;
import java.util.Arrays;

public class Student {
    private String name;
    private String dob;
    private char gender;
    private String mode;
    private String year;
    private int modules;
    private double fees;
        
    public Student(String newName, String newDob, char newGender, String newMode, String newYear, int newModules){
        
        name = newName;
        dob = newDob; 
        gender = newGender;
        mode = newMode;
        year = newYear;
        modules = newModules;
      
    }
    
    public String getName(){
        return name;
    }
    public String getDoB(){
        return dob;
    }
    public char getGender(){
        return gender;
    }
    public String getMode(){
        return mode;
    }
    public String getYear(){
        return year;
    }
    public int getModule(){
        return modules;
    }
    public void setFees(double f)
    {
        this.fees = f;
    }
    public double getFees(){
        return fees;
    }
    
    public double computingFee(){        
         return getFees();
    }
    
}