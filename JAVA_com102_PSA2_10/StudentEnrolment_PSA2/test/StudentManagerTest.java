/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Owner
 */
public class StudentManagerTest {

    public StudentManagerTest(){
    }
    /**
     * Test of addName method, of class StudentManager.
     */
   @Test
    public void testGetName() 
    {
        System.out.println("Test getName method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        String expectedResult = "Ryan";
        
        String actualResult = s.getName();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }
     
    @Test
    public void testGetDOB() 
    {
        System.out.println("Test getDOB method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        String expectedResult = "26/11/2003";
        
        String actualResult = s.getDoB();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }
    @Test
    public void testGetGender() 
    {
        System.out.println("Test getGender method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        char expectedResult = 'm';
        
        char actualResult = s.getGender();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }
    @Test
    public void testGetMode() 
    {
        System.out.println("Test getMode method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        String expectedResult = "PT";
        
        String actualResult = s.getMode();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }
    @Test
     public void testGetYear() 
    {
        System.out.println("Test getYear method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        String expectedResult = "2";
        
        String actualResult = s.getYear();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }
     @Test
      public void testGetModule() 
    {
        System.out.println("Test getModule method");
        Student s = new Student("Ryan","26/11/2003",'m',"PT","2",3);
        
        int expectedResult = 3;
        
        int actualResult = s.getModule();
        
        assertEquals(expectedResult, actualResult);
        // TODO review the generated test code and remove the default call to fail.
    }             
}
