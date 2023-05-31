using System;

class App {

    static string logo = @"
  ______     ___       __        ______  __    __   __          ___   .___________..______       __    ______  _______ 
 /      |   /   \     |  |      /      ||  |  |  | |  |        /   \  |           ||   _  \     |  |  /      ||   ____|
|  ,----'  /  ^  \    |  |     |  ,----'|  |  |  | |  |       /  ^  \ `---|  |----`|  |_)  |    |  | |  ,----'|  |__   
|  |      /  /_\  \   |  |     |  |     |  |  |  | |  |      /  /_\  \    |  |     |      /     |  | |  |     |   __|  
|  `----./  _____  \  |  `----.|  `----.|  `--'  | |  `----./  _____  \   |  |     |  |\  \----.|  | |  `----.|  |____ 
 \______/__/     \__\ |_______| \______| \______/  |_______/__/     \__\  |__|     | _| `._____||__|  \______||_______|
                                                                                                                       
  ______      __    __   __     .__   __.  __    ______      __    __   _______    
 /  __  \    |  |  |  | |  |    |  \ |  | |  |  /  __  \    |  |  |  | |   ____|   
|  |  |  |   |  |  |  | |  |    |   \|  | |  | |  |  |  |   |  |  |  | |  |__      
|  |  |  |   |  |  |  | |  |    |  . `  | |  | |  |  |  |   |  |  |  | |   __|     
|  `--'  '--.|  `--'  | |  |    |  |\   | |  | |  `--'  '--.|  `--'  | |  |____    
 \_____\_____\\______/  |__|    |__| \__| |__|  \_____\_____\\______/  |_______|   

 _______   _______     _______.    _______       ___      .______        ______   .__   __. .__   __.  _______     _______.
|       \ |   ____|   /       |   |       \     /   \     |   _  \      /  __  \  |  \ |  | |  \ |  | |   ____|   /       |
|  .--.  ||  |__     |   (----`   |  .--.  |   /  ^  \    |  |_)  |    |  |  |  | |   \|  | |   \|  | |  |__     |   (----`
|  |  |  ||   __|     \   \       |  |  |  |  /  /_\  \   |      /     |  |  |  | |  . `  | |  . `  | |   __|     \   \    
|  '--'  ||  |____.----)   |      |  '--'  | /  _____  \  |  |\  \----.|  `--'  | |  |\   | |  |\   | |  |____.----)   |   
|_______/ |_______|_______/       |_______/ /__/     \__\ | _| `._____| \______/  |__| \__| |__| \__| |_______|_______/    
                                                                                                                           
                                                                                   
    ";

    static string instructions = @"
    Comment l'utiliser :
    - saisir un nombre et faites la touche entrer avant d'en saisir un autre. 
    - saisir un nombre puis faire entrer puis saisir un opérateur et refaire entrer avant de saisir un nouveau nombre
    - Fait toujours entrer sinon je vais te niquer ta mere
    - Les opérateurs supporter sont : *, /, +, -
    - Pour voir le resultat du calcul saisi '=' et faire entrer
    - Saisir 'stop' et faire entrer pour arreter le programme
    - Saisir clear pour réinitialiser la calculatrice

    Entrez soit un nombre soit un opertateur puis faire enter
    ";
    static void Main(string[] args) {
        Console.Clear();
        bool run = true;
        int res = 0;
        char prevOp = '#';
        string history = "";
        displayInfo();
        do {
            string? userInput =  Console.ReadLine();
            string[] commands = new string[] {"clear", "history", "stop"};
            if(Array.IndexOf(commands, userInput) == -1) {
                history += userInput;
            }
            switch (userInput){
                case "clear":
                    reinit(res, history, prevOp);  
                    break;
                case "stop":
                    run=false;
                    break;
                case "+":
                    prevOp = '+';     
                    break;
                case "-":
                    prevOp = '-';
                    break;
                case "*":
                    prevOp = '*';
                    break;
                case "/": 
                    prevOp = '/';
                    break;
                case "history": 
                    Console.WriteLine("History : ");
                    Console.WriteLine("res : " + res);
                    break;
                default:
                    if(userInput != null && int.TryParse(userInput, out int number)) {
                        res = calc(res, number, prevOp);
                    } 
                    break;
            }
            if(userInput != null)  
                writeHistory(history, userInput, res);
            
        } while (run);
    }

    public static void displayInfo() {
        Console.WriteLine(logo);
        Console.WriteLine(instructions);
    }
    public static void writeHistory(string history, string userInput, int res) {
        if(userInput != "=") {
            Console.WriteLine(history);
        } else {
            history += res;
            Console.WriteLine(history);
        }
    }

    public static void reinit(int res, string history, char prevOp) {
        res = 0;
        history= "";
        prevOp = '#';
        Console.Clear();
        displayInfo();
    }

    public static int calc(int first, int second, Char op) {
        int res = first;
            switch (op){ 
                    case '+':
                        res += second;         
                        break;
                    case '-':
                        res -= second;
                        break;
                    case '*':
                        res *= second;
                        break;
                    case '/': 
                        res /= second;
                        break;
                    default: 
                        res = second;
                        break;
                }
        return res;
    }
}
