using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static Modules;


// GPU
List<GPU> SelectGPU = new List<GPU>()
{
    new GPU("Qualcomm", "Adreno 642L", 550, true),
    new GPU("Qualcomm", "Adreno 740", 719, true),
    new GPU("Qualcomm", "Adreno 619", 500, false),
    new GPU("HiSilicon", "ARM Mali-G76 MP10", 720, true),
    new GPU("A15 Bionic", "Apple GPU", 800, false),
    new GPU("Unisoc", "ARM Mali-G76 MP10", 680, true)
};

// CPU
List<Processor> SelectProcessor = new List<Processor>()
{
    new Processor("Cortex A78", 6, 8, 64),
    new Processor("Cortex A55", 4, 8, 64),
    new Processor("Cortex X3", 8, 8, 64),
    new Processor("Cortex A710", 7, 8, 64),
    new Processor("Cortex A510", 8, 8, 64),
    new Processor("Cortex A76", 7, 8, 64),
    new Processor("Avalanche", 6, 5, 64),
    new Processor("Blizzard", 6, 5, 64),
    new Processor("Cortex A75", 12, 8, 64)
};

// Modules
List<Modems> moduleModems = new List<Modems>
{
    Modems._1G,
    Modems._2G,
    Modems._3G,
    Modems.LTE,
    Modems._5G,
    Modems.Bluetooth,
    Modems.WiFi,
    Modems.GPRS,
    Modems.GSM,
    Modems.HSPA
};

List<Sensors> moduleSensors = new List<Sensors>
{
    Sensors.Temperature,
    Sensors.Accelerometer,
    Sensors.MagneticField,
    Sensors.Gyroscope,
    Sensors.Light,
    Sensors.Gravity,
    Sensors.Rotation,
    Sensors.Pedometer,
    Sensors.Proximity,
    Sensors.Orientation,
    Sensors.Fingerprint,
    Sensors.Compass,
    Sensors.HallSensor,
    Sensors.IRBlaster
};

// RAM
List<RAM> SelectRAM = new List<RAM>()
{
    new RAM("First", RAM.RamType.LPDDR1, 6, 200),
    new RAM("First", RAM.RamType.LPDDR1E, 6, 266),
    new RAM("Second", RAM.RamType.LPDDR2, 6, 400),
    new RAM("Second", RAM.RamType.LPDDR2E, 6, 533),
    new RAM("Third", RAM.RamType.LPDDR3, 6, 800),
    new RAM("Third", RAM.RamType.LPDDR3E, 6, 1067),
    new RAM("Fourth", RAM.RamType.LPDDR4, 6, 1600),
    new RAM("Fourth", RAM.RamType.LPDDR4X, 6, 2133),
    new RAM("Fifth", RAM.RamType.LPDDR5, 6, 3200),
    new RAM("Fifth", RAM.RamType.LPDDR5X, 6, 4267)
};

// Storage
List<Storage> SelectStorage = new List<Storage>()
{
    new Storage("Samsung", 128, "Android 11", true),
    new Storage("Samsung", 512, "Android 13", true),
    new Storage("Nokia", 64, "Android 11", true),
    new Storage("Huawei", 256, "EMUI 10", true),
    new Storage("Apple", 256, "iOS 16", false),
    new Storage("Techno", 128, "HiOS 8.6", true),
};

// SoC
/*List<SOC> SelectSOC = new List<SOC>()   //WIll have to modify during implementation (SOC inputs depend on previous decisions)
{
    new SOC("Qualcomm", "Snapdragon 778G", "SM7325", SelectProcessor[1], SelectGPU[1], modules, ram, storage),
    new SOC("Qualcomm", "Snapdragon 8 Gen 2", "Kalama", SelectProcessor[1], SelectGPU[1], modules, ram, storage),
    new SOC("Qualcomm", "Snapdragon 480", "SM4350", SelectProcessor[1], SelectGPU[1], modules, ram, storage),
    new SOC("HiSilicon", "Kirin", "KIRIN 980", SelectProcessor[1], SelectGPU[1], modules, ram, storage),
    new SOC("Apple", "A15 Bionic", "APL1W07", SelectProcessor[1], SelectGPU[1], modules, ram, storage),
    new SOC("Unisoc", "Tiger", "T606", SelectProcessor[1], SelectGPU[1], modules, ram, storage)
};*/

// Display
//int[] Res = new int[2] { 1080, 2400 }; //WIll have to modify during implementation (Input or select two ints)
/*List<Display> SelectDisplay = new List<Display>()  
{
    new Display("Super AMOLED", Res, 6.5, 120, "Corning Gorilla Glass 5"),
    new Display("Dynamic AMOLED 2X", Res, 6.1, 120, "Corning Gorilla Glass Victus 2"),
    new Display("IPS", Res, 6.67, 60, "2D Curved Glass Screen"),
    new Display("OLED", Res, 6.1, 90, "Corning Gorilla Glass"),
    new Display("OLED", Res, 6, 60, "Ceramic Shield"),
    new Display("IPS", Res, 6.03, 90, "2.5D Curved Glass Screen")
};*/

// Battery
List<Battery> SelectBattery = new List<Battery>()
{
    new Battery("Li-Ion", 4500, 5, 1, false),
    new Battery("Li-Polymer", 3900, 3.7, 0.8, false),
    new Battery("Li-Polymer", 4470, 9, 0.8, false),
    new Battery("Li-Polymer", 3650, 5, 0.5, false),
    new Battery("Li-Ion", 3000, 5, 1, false),
    new Battery("Li-Polymer", 5000, 9, 1.2, false)
};

// Camera
List<Camera> SelectCameras = new List<Camera>()
{
    new Camera("Front camera", 64, "f/1.8", 0.8, true),
    new Camera("Front camera", 12, "f/2.2", 1.12, true),
    new Camera("Front camera", 5, "f/2.4", 1.16, true),
    new Camera("Front camera", 5, "f/2.4", 1.16, true),
    new Camera("Rear camera", 32, "f/2.2", 0.8, false),
    new Camera("Rear camera", 12, "f/2.1", 1.02, false),
    new Camera("Rear camera", 5, "f/2.4", 1.12, false)
};

// Case
//Case @case1 = new Case("Samsung", "A52s 5G", soc, display, cameras, battery); //WIll have to modify during implementation (Name and Model)
//Case @case2 = new Case("iPhone", "XS");
//Case @case3 = new Case();


//Perhaps implement the ability to save, compare, generate Hash, get by names and types

string? userChoice = null;
int choiceCount = 0;
int i = 1;
int temp;
int[] Res = new int[2];
ArrayList selMod = new ArrayList();
ArrayList selSen = new ArrayList();
GPU SelectedGPU = new GPU();
Processor SelectedProcessor = new Processor();
RAM SelectedRAM = new RAM();
Storage SelectedStorage = new Storage();
List<Modems> SelectedModems = new List<Modems>();
List<Sensors> SelectedSensors = new List<Sensors>();
Battery SelectedBattery = new Battery();
Display SelectedDisplay = new Display();
List<Camera> SelectedCameras = new List<Camera>();
ArrayList selCam = new ArrayList();

List<Display> SelectDisplay = new List<Display>()
{
    new Display("Super AMOLED", Res, 6.5, 120, "Corning Gorilla Glass 5"),
    new Display("Dynamic AMOLED 2X", Res, 6.1, 120, "Corning Gorilla Glass Victus 2"),
    new Display("IPS", Res, 6.67, 60, "2D Curved Glass Screen"),
    new Display("OLED", Res, 6.1, 90, "Corning Gorilla Glass"),
    new Display("OLED", Res, 6, 60, "Ceramic Shield"),
    new Display("IPS", Res, 6.03, 90, "2.5D Curved Glass Screen")
};

// Select GPU
while (userChoice != "exit" && choiceCount == 0)
{
    i = 1;
    Console.WriteLine("Please select one of the following GPU options:");
    foreach (var gpu in SelectGPU)
    {
        Console.WriteLine(i + ". " + gpu.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedGPU = SelectGPU[i - 1];
            choiceCount = 1;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6, or 'exit' to quit.");
            break;
    }
}

// Select Processor
while (userChoice != "exit" && choiceCount == 1)
{
    i = 1;
    Console.WriteLine("Please select one of the following Processor options:");
    foreach (var processor in SelectProcessor)
    {
        Console.WriteLine(i + ". " + processor.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "7":
            Console.WriteLine("You selected Option 7.");
            i = 7;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "8":
            Console.WriteLine("You selected Option 8.");
            i = 8;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "9":
            Console.WriteLine("You selected Option 9.");
            i = 9;
            SelectedProcessor = SelectProcessor[i - 1];
            choiceCount = 2;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 9, or 'exit' to quit.");
            break;
    }
}

// Select RAM
while (userChoice != "exit" && choiceCount == 2)
{
    i = 1;
    Console.WriteLine("Please select one of the following RAM options:");
    foreach (var ram in SelectRAM)
    {
        Console.WriteLine(i + ". " + ram.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "7":
            Console.WriteLine("You selected Option 7.");
            i = 7;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "8":
            Console.WriteLine("You selected Option 8.");
            i = 8;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "9":
            Console.WriteLine("You selected Option 9.");
            i = 9;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "10":
            Console.WriteLine("You selected Option 10.");
            i = 10;
            SelectedRAM = SelectRAM[i - 1];
            choiceCount = 3;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 10, or 'exit' to quit.");
            break;
    }
}

// Select Storage
while (userChoice != "exit" && choiceCount == 3)
{
    i = 1;
    Console.WriteLine("Please select one of the following RAM options:");
    foreach (var storage in SelectStorage)
    {
        Console.WriteLine(i + ". " + storage.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedStorage = SelectStorage[i - 1];
            choiceCount = 4;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6, or 'exit' to quit.");
            break;
    }
}

// Select Modems
while (userChoice != "exit" && choiceCount == 4)
{
    bool finish = true;
    bool enWrite = true;
    i = 1;
    Console.WriteLine("Please select one or more of the following Modem options:");
    foreach (var modem in moduleModems)
    {
        Console.WriteLine(i + ". " + modem);
        i++;
    }

    while (finish)
    {
        enWrite = true;
        Console.Write("Enter your choice (Enter '0' if no additonal Modems are needed): ");
        temp = Convert.ToInt32(Console.ReadLine()) - 1;

        foreach (int choice in selMod)
        {
            if (choice == temp)
            {
                enWrite = false;
            }
        }

        if(enWrite == false)
        {
            Console.WriteLine("Already chosen. Please choose another one.");
        }
        else
        {
            switch (temp)
            {
                case 0:
                    Console.WriteLine("You selected Option 1.");
                    selMod.Add(temp);
                    break;
                case 1:
                    Console.WriteLine("You selected Option 2.");
                    selMod.Add(temp);
                    break;
                case 2:
                    Console.WriteLine("You selected Option 3.");
                    selMod.Add(temp);
                    break;
                case 3:
                    Console.WriteLine("You selected Option 4.");
                    selMod.Add(temp);
                    break;
                case 4:
                    Console.WriteLine("You selected Option 5.");
                    selMod.Add(temp);
                    break;
                case 5:
                    Console.WriteLine("You selected Option 6.");
                    selMod.Add(temp);
                    break;
                case 6:
                    Console.WriteLine("You selected Option 7.");
                    selMod.Add(temp);
                    break;
                case 7:
                    Console.WriteLine("You selected Option 8.");
                    selMod.Add(temp);
                    break;
                case 8:
                    Console.WriteLine("You selected Option 9.");
                    selMod.Add(temp);
                    break;
                case 9:
                    Console.WriteLine("You selected Option 10.");
                    selMod.Add(temp);
                    break;
                case -1:
                    finish = false;
                    Console.WriteLine("Exiting modems!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 10, or '0' to quit.");
                    break;
            }
        }
    }


    foreach (int choice in selMod)
    {
        SelectedModems.Add(moduleModems[choice]);
    }

    choiceCount = 5;
}

// Select Sensors
while (userChoice != "exit" && choiceCount == 5)
{
    bool finish = true;
    bool enWrite = true;
    i = 1;
    Console.WriteLine("Please select one or more of the following Sensor options:");
    foreach (var sensor in moduleSensors)
    {
        Console.WriteLine(i + ". " + sensor);
        i++;
    }

    while (finish)
    {
        enWrite = true;
        Console.Write("Enter your choice (Enter '0' if no additonal Sensors are needed): ");
        temp = Convert.ToInt32(Console.ReadLine()) - 1;

        foreach (int choice in selSen)
        {
            if (choice == temp)
            {
                enWrite = false;
            }
        }

        if (enWrite == false)
        {
            Console.WriteLine("Already chosen. Please choose another one.");
        }
        else
        {
            switch (temp)
            {
                case 0:
                    Console.WriteLine("You selected Option 1.");
                    selSen.Add(temp);
                    break;
                case 1:
                    Console.WriteLine("You selected Option 2.");
                    selSen.Add(temp);
                    break;
                case 2:
                    Console.WriteLine("You selected Option 3.");
                    selSen.Add(temp);
                    break;
                case 3:
                    Console.WriteLine("You selected Option 4.");
                    selSen.Add(temp);
                    break;
                case 4:
                    Console.WriteLine("You selected Option 5.");
                    selSen.Add(temp);
                    break;
                case 5:
                    Console.WriteLine("You selected Option 6.");
                    selSen.Add(temp);
                    break;
                case 6:
                    Console.WriteLine("You selected Option 7.");
                    selSen.Add(temp);
                    break;
                case 7:
                    Console.WriteLine("You selected Option 8.");
                    selSen.Add(temp);
                    break;
                case 8:
                    Console.WriteLine("You selected Option 9.");
                    selSen.Add(temp);
                    break;
                case 9:
                    Console.WriteLine("You selected Option 10.");
                    selSen.Add(temp);
                    break;
                case 10:
                    Console.WriteLine("You selected Option 11.");
                    selMod.Add(temp);
                    break;
                case 11:
                    Console.WriteLine("You selected Option 12.");
                    selMod.Add(temp);
                    break;
                case 12:
                    Console.WriteLine("You selected Option 13.");
                    selMod.Add(temp);
                    break;
                case 13:
                    Console.WriteLine("You selected Option 14.");
                    selMod.Add(temp);
                    break;
                case -1:
                    finish = false;
                    Console.WriteLine("Exiting sensors!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 14, or '0' to quit.");
                    break;
            }
        }
    }


    foreach (int choice in selSen)
    {
        SelectedSensors.Add(moduleSensors[choice]);
    }

    choiceCount = 6;
}

// Creating Modules object
Modules modules = new Modules("Modules included", SelectedModems, SelectedSensors); //WIll have to modify during implementation (Modules have to be grouped)

// Creating SoC object presets
List<SOC> SelectSOC = new List<SOC>()   //WIll have to modify during implementation (SOC inputs depend on previous decisions)
{
    new SOC("Qualcomm", "Snapdragon 778G", "SM7325", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage),
    new SOC("Qualcomm", "Snapdragon 8 Gen 2", "Kalama", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage),
    new SOC("Qualcomm", "Snapdragon 480", "SM4350", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage),
    new SOC("HiSilicon", "Kirin", "KIRIN 980", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage),
    new SOC("Apple", "A15 Bionic", "APL1W07", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage),
    new SOC("Unisoc", "Tiger", "T606", SelectedProcessor, SelectedGPU, modules, SelectedRAM, SelectedStorage)
};

SOC SelectedSOC = new SOC();

// Select SOC
while (userChoice != "exit" && choiceCount == 6)
{
    i = 1;
    Console.WriteLine("Please select one of the following SoC options:");
    foreach (var soc in SelectSOC)
    {
        Console.WriteLine(i + ". " + soc.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedSOC = SelectSOC[i - 1];
            choiceCount = 7;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6, or 'exit' to quit.");
            break;
    }
}

// Select Battery
while (userChoice != "exit" && choiceCount == 7)
{
    i = 1;
    Console.WriteLine("Please select one of the following Battery options:");
    foreach (var battery in SelectBattery)
    {
        Console.WriteLine(i + ". " + battery.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedBattery = SelectBattery[i - 1];
            choiceCount = 8;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6, or 'exit' to quit.");
            break;
    }
}

// Select Display
while (userChoice != "exit" && choiceCount == 8)
{

    Console.Write("Input your desired Resolution Width in px: ");
    Res[0] = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input your desired Resolution Height in px: ");
    Res[1] = Convert.ToInt32(Console.ReadLine());

    i = 1;
    Console.WriteLine("Please select one of the following Display options:");
    foreach (var display in SelectDisplay)
    {
        Console.WriteLine(i + ". " + display.Description);
        i++;
    }

    Console.Write("Enter your choice: ");

    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            Console.WriteLine("You selected Option 1.");
            i = 1;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "2":
            Console.WriteLine("You selected Option 2.");
            i = 2;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "3":
            Console.WriteLine("You selected Option 3.");
            i = 3;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "4":
            Console.WriteLine("You selected Option 4.");
            i = 4;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "5":
            Console.WriteLine("You selected Option 5.");
            i = 5;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "6":
            Console.WriteLine("You selected Option 6.");
            i = 6;
            SelectedDisplay = SelectDisplay[i - 1];
            choiceCount = 9;
            break;
        case "exit":
            choiceCount = -1;
            Console.WriteLine("Bye bye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6, or 'exit' to quit.");
            break;
    }
}

// Select Cameras
while (userChoice != "exit" && choiceCount == 9)
{
    bool finish = true;
    i = 1;
    Console.WriteLine("Please select one or more of the following Camera options:");
    foreach (var camera in SelectCameras)
    {
        Console.WriteLine(i + ". " + camera.Description);
        i++;
    }

    while (finish)
    {
        Console.Write("Enter your choice (Enter '0' if no additonal Cameras are needed): ");
        temp = Convert.ToInt32(Console.ReadLine()) - 1;

            switch (temp)
            {
                case 0:
                    Console.WriteLine("You selected Option 1.");
                    selCam.Add(temp);
                    break;
                case 1:
                    Console.WriteLine("You selected Option 2.");
                    selCam.Add(temp);
                    break;
                case 2:
                    Console.WriteLine("You selected Option 3.");
                    selCam.Add(temp);
                    break;
                case 3:
                    Console.WriteLine("You selected Option 4.");
                    selCam.Add(temp);
                    break;
                case 4:
                    Console.WriteLine("You selected Option 5.");
                    selCam.Add(temp);
                    break;
                case 5:
                    Console.WriteLine("You selected Option 6.");
                    selCam.Add(temp);
                    break;
                case 6:
                    Console.WriteLine("You selected Option 7.");
                    selCam.Add(temp);
                    break;
                case -1:
                    finish = false;
                    Console.WriteLine("Exiting cameras!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 7, or '0' to quit.");
                    break;
            }
    }

    foreach (int choice in selCam)
    {
        SelectedCameras.Add(SelectCameras[choice]);
    }

    choiceCount = 10;
}

bool running = true;

if (choiceCount == 10)
{
    Console.Write("What's the phone's Vendor: ");
    string? Vendor = Console.ReadLine();
    Console.Write("What's the phone's Model:  ");
    string? Model = Console.ReadLine();

    Case @case = new Case(Vendor, Model, SelectedSOC, SelectedDisplay, SelectedCameras, SelectedBattery);

    Console.WriteLine(@case.GetFullDescription());

    Console.WriteLine("Do you want to generate the Hash code?\ty/n");
    char Answer = Console.ReadLine()[0];

    switch (Answer)
    {
        case 'y':
            Console.WriteLine("Generated Hash code: {0} \n", @case.GetHashCode());
            break;
        case 'n':
            Console.WriteLine("Hash not generated.");
            break;
        default:
            Console.WriteLine("Please choose the appropriate option.");
            break;
    }

    int chosenNumber;
    string elName;
    while (running)
    {
        Console.WriteLine(
                $"\nChoose 1 to GetElementByName;\n" +
                $"Choose 2 to GetElementsByName;\n" +
                $"Choose 1 to GetElementByType;\n" +
                $"Choose 4 to GetElementsByType;\n" +
                $"Choose 5 to GetAllElements;\n" +
                $"Choose 0 to Exit;\n");
        chosenNumber = Convert.ToInt32(Console.ReadLine());

        switch (chosenNumber)
        {
            case 0:
                Console.WriteLine($"Bye bye!\n");
                running = false;
                break;
            case 1:
                Console.WriteLine($"Choose 1 to GetElementByName;\n");
                elName = Console.ReadLine();
                Console.WriteLine("Results:\n\n{0}", @case.GetElementsByName(elName));
                break;
            case 2:
                Console.WriteLine($"Choose 2 to GetElementsByName;\n");
                elName = Console.ReadLine();
                Console.WriteLine("Results:\n\n{0}", @case.GetElementsByName(elName));
                break;
            case 3:
                Console.WriteLine($"Choose 3 to GetElementByType;\n");
                Console.WriteLine("Not yet implemented");
                break;
            case 4:
                Console.WriteLine($"Choose 4 to GetElementsByType;\n");
                Console.WriteLine("Not yet implemented");
                break;
            case 5:
                Console.WriteLine($"Choose 5 to GetAllElements;\n");
                Console.WriteLine("Results:\n\n{0}", @case.GetAllElements());
                break;
            default:
                Console.WriteLine("Please choose the appropriate option.");
                break;
        }

    }



}
else
{
    Console.WriteLine("Phone missing parts. Sorry, no phone for you! ");
}
