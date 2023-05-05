/*
 This is the Part time class which is a child class of the Student class, allowing it to access the variables within that class. This class
 is used whenever a Part Time staff is registered as the fees per student differ depending on their study mode.
 */

/**
 *
 * @author b00884706
 */
public class PT extends Student {
    
    private int moduleRate = 750;
    
    
    public PT(String newName, String newDob, char newGender, String newYear, String newMode, int newModules){
        
        super(newName, newDob, newGender, newMode, newYear, newModules);
    }
    
   // public void setCost(int y){
   //     int cost = y*750;
   //     setFees(cost);
   // }
    
      @Override
    public double computingFee(){
        setFees(getModule()*moduleRate);
       //Just a random number to prevent a no return error
         return getFees();
    }
}
