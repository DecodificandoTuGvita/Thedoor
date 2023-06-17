namespace Thedoor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Welcome, please put a new password for your new door");
              string userimput = Console.ReadLine();
            string newpassword = "";
            Door door = new Door(userimput);
            Action[] DoorComands = new Action[] { () => door.Open(userimput), () => door.Close(), door.locked, () => door.changepassword(),()=>door.unlock(userimput) };
            do { 
            string[] useoptions = new string[] {"0- open the door", "1-close the door","2-lock the door","3-change password" };
            foreach (string option in useoptions)
            {

                Console.WriteLine($"option {option}");


            }

             userimput = Console.ReadLine();
            

            
            

            switch(userimput) {

                case "0":  DoorComands[0]();         break;
                case "1":
                   
                     DoorComands[1](); break;
                case "2": DoorComands[2](); break;
                case "3": DoorComands[3](); break;

                case "4":  
                    DoorComands[4](); break;
                  //  case "5":  DoorComands[4](); break;
                  default: Console.WriteLine("mamabicho por favor, selecciona un numero valido"); break;

                }

            }while(true);

        }
    }
    public class Door{

        public DoorStatus CurrentStatus {get;set;} 
        private string Passcode { get;set;}  

        public Door(string Passcode) { 
        
        this.Passcode = Passcode;
            CurrentStatus = DoorStatus.Locked;

        
        }


        public void GetStatus() {


            Console.WriteLine($"The current door status is {CurrentStatus.ToString()}");
        
        }
        public bool unlock(string Passcode)
        {
            if(Passcode==this.Passcode)return true;
            else { Console.WriteLine("Password incorrect");
            return false;}

        }
        public void Open(string Passcode="") {

            if (CurrentStatus == DoorStatus.Locked)
            {
                Console.WriteLine("please write the password");
               Passcode= Console.ReadLine();
                if (unlock(Passcode) == false) return;
                CurrentStatus = DoorStatus.Open;
                GetStatus();
               
               



            }
            else { 
            CurrentStatus = DoorStatus.Open;
            GetStatus();
            }


        }
        public void Close() {


            if (CurrentStatus == DoorStatus.Open) { CurrentStatus = DoorStatus.Closed; GetStatus(); }
            else { Console.WriteLine("incompatible status"); GetStatus(); }
        
        
        }
        public void locked() { 
        if (CurrentStatus == DoorStatus.Locked) { Console.WriteLine("status not compatible"); GetStatus(); return; }
        CurrentStatus= DoorStatus.Locked;
            GetStatus(); 
        
        
        }
        public void changepassword() {
            Console.WriteLine("please write your old password"); string OldPasscode = Console.ReadLine();
            Console.WriteLine("now please introduce your new password");string Newpasscode = Console.ReadLine();

            if (OldPasscode==this.Passcode&&Newpasscode!=this.Passcode) this.Passcode=Newpasscode;
        
        Console.WriteLine($"your new passcode is the following {Passcode}");    
        
        }
    
    
    }



   public enum DoorStatus {Open,Closed,Locked }
}