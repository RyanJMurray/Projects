/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*This is the Student Main class, where the project and main methods will be executed. In This class, a Student manager object is
  instantiated to access the methods to be executed within the Student Manager class. The student and studentRegister arrays stores 
  information regarding the student when reading in values from the textfile and adding/deleting new students. 
*/


/**
 *
 * @author b00882569
 */

public class StudentMain {
    
    //Student manager object is created
    static  StudentManager sm = new StudentManager();
    //Student and studentRegister array is made to store the student details for reading/writing
    String [] student = new String[20];  
    Student [] studentRegister = new Student [20];
  
    public static void main(String[] args){ 
        //Start method is executed, starting the enrolment system
         sm.start();
    }                
}

