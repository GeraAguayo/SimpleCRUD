using System;
using System.Diagnostics;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        banner();
        Console.WriteLine("What kinda of data you want to store? ");
        Console.WriteLine("1 - Integers numbers");
        Console.WriteLine("2 - Double numbers");
        Console.WriteLine("3 - Strings");
        Console.WriteLine("4 - Exit");
        int option = 0;


        //Get the type of array
        try
        {
            option = Convert.ToInt32(Console.ReadLine());

            //Check if the user want to exit
            if (option == 4) {
                banner();
                Console.WriteLine("Bay!");
                System.Environment.Exit(1);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.ToString());
        }

        //Set the size of the array
        banner();
        Console.WriteLine("Enter the size of the array: ");
        int size = Convert.ToInt32(Console.ReadLine());

        //Select the type of array
        switch (option)
        {
            case 1:
                int[] arrayInt = new int[size];
                manageArrayInt(arrayInt);
                break;

            case 2:
                double[] arrayDouble = new double[size];
                manageArrayDouble(arrayDouble);
                break;

            case 3:
                string[] arrayString = new string[size];
                manageArrayStr(arrayString);
                break;

            case 4:
                exit();
                break;

            default:
                Console.WriteLine("Enter a valid option");
                break;
        }
    }

    static void banner()
    {
        Console.Clear();
        Console.WriteLine("C  R  U  D");
        Console.WriteLine(" - - - - - - -");
        Console.WriteLine("\n");
    }

    static void exit()
    {
        banner();
        Console.WriteLine("Bye!");
        System.Environment.Exit(1);
    }

    static void manageArrayInt(int[]array)
    {
        banner();
        Console.WriteLine("What do you want to do: ");
        Console.WriteLine("1 - Add data to the array");
        Console.WriteLine("2 - Remove data from the array");
        Console.WriteLine("3 - See the data");
        Console.WriteLine("4 - Update data");
        Console.WriteLine("5 - Exit");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:

                //Add data
                void addData()
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        banner();
                        int counter = i + 1;
                        Console.WriteLine(counter + "-" + "Enter the number to put in the array: ");
                        int data = Convert.ToInt32(Console.ReadLine());
                        array[i] = data;
                    }
                    manageArrayInt(array);

                }
                addData();
                break;
            case 2:
                //Remove data
                void removeData()
                {
                    banner();
                    Console.WriteLine("Remove data from the array");
                    Console.WriteLine("1 - Remove from index");
                    Console.WriteLine("2 - Remove from value");
                    Console.WriteLine("3 - Remove all the data");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option){
                        case 1:
                            //Remove from index
                            banner();
                            showData(array);
                            Console.WriteLine("Type the index you want to delete: ");
                            int indexToDelete = Convert.ToInt32(Console.ReadLine());
                            array = removeFromIndex(array, indexToDelete);
                            preExit(array);

                            break;
                        case 2:
                            //Remove from value
                            banner();
                            showData(array);
                            Console.WriteLine("Type the value you want to delete: ");
                            int del = Convert.ToInt32(Console.ReadLine());

                            //Get the index from the element of the array
                            int index = Array.IndexOf(array, del);

                            //Remove the data from the array
                            array = removeFromIndex(array, index);

                            preExit(array);

                            break;
                        case 3:
                            //Remove all the data
                            banner();
                            Array.Clear(array, 0, array.Length);
                            showData(array);
                            preExit(array);
                            break;

                        default:
                            banner();
                            Console.WriteLine("Enter a valid option!");
                            removeData();
                            break;

                    }

                }
                removeData();
                break;
            case 3:
                //Show the data
                showData(array);
                preExit(array);
                
                break;
            case 4:
                //Update data
                updateData(array);
                break;
            case 5:
                //Exit from the app
                exit();
                break;

            default:
                Console.WriteLine("Enter a valid option");
                Main(null);
                break;
        }


        
    }

    //Functions for an array of integers
    static void showData(int[] array)
    {
        banner();
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Index: " + i + ", Value: " + array[i]);
        }
        
    }

    static void preExit(int[] array)
    {
        //Ask if the user want to exit or to return to the menu
        Console.WriteLine("\nType M to go back to the menu");
        Console.WriteLine("Or type E to exit from the app");
        string input = Console.ReadLine();
        input = input.ToLower();

        if (input == "m")
        {
            //Go back to the menu
            manageArrayInt(array);
        }
        else if (input == "e")
        {
            //Exit from app
            exit();
        }

    }

    static int[] removeFromIndex(int[]array, int index)
    {
        //Shift elments position
        for (int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        //Resize array
        Array.Resize(ref array, array.Length - 1);

        //Show array with changes
        showData(array);

        return array;

    }

    static int[] updateData(int[] array)
    {
        banner();
        Console.WriteLine("1 - Update from index");
        Console.WriteLine("2 - Update from value");
        Console.WriteLine("3 - Exit");
        int opt = Convert.ToInt32(Console.ReadLine());

        switch (opt)
        {
            case 1:
                //Update from index
                showData(array);
                Console.WriteLine("Type the index you want to modify:");
                int indexMod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the new value you want to enter:");
                int newValue = Convert.ToInt32(Console.ReadLine());

                //Find the value in the array
                for( int i = 0; i < array.Length; i++)
                {
                    if (i == indexMod)
                    {
                        array[i] = newValue;
                        break;
                    }
                }

                showData(array);
                Console.WriteLine("The array has been updated!");
                preExit(array);
                break;
            case 2:
                //Update from value
                showData(array);
                Console.WriteLine("Type the value you want to modify:");
                int valueMod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the new value you want to enter:");
                int newVal = Convert.ToInt32(Console.ReadLine());

                //Search the value and obtain the index
                int index = Array.IndexOf(array, valueMod);

                //Modify the value
                array[index] = newVal;

                showData(array);
                Console.WriteLine("The value has been updated!");
                preExit(array);

                break;
            case 3:
                //Exit
                preExit(array);
                break;
            default:
                Console.WriteLine("Enter a valid option!!!!!");
                System.Threading.Thread.Sleep(500);
                updateData(array);
                break;



        }


        return array;
    }
    

    static void manageArrayDouble(double[]array)
    {
        banner();
        Console.WriteLine("What do you want to do: ");
        Console.WriteLine("1 - Add data to the array");
        Console.WriteLine("2 - Remove data from the array");
        Console.WriteLine("3 - See the data");
        Console.WriteLine("4 - Update data");
        Console.WriteLine("5 - Exit");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                //Add data
                for(int i = 0; i < array.Length; i++)
                {
                    banner();
                    int count = i + 1;
                    Console.WriteLine(count + "- Enter the number (double) to put in the array: ");
                    double data = Convert.ToDouble(Console.ReadLine());
                    array[i] = data;
                }

                Console.WriteLine("\nAll data has been created!");
                System.Threading.Thread.Sleep(500);
                manageArrayDouble(array);

                break;
            case 2:
                //Remove data
                Console.WriteLine("Remove data");
                void removeData(double[]array)
                {
                    banner();
                    Console.WriteLine("Remove data from the array");
                    Console.WriteLine("1 - Remove from index");
                    Console.WriteLine("2 - Remove from value");
                    Console.WriteLine("3 - Remove all the data");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option) {

                        case 1:
                            //Remove from index
                            banner();
                            showDataDouble(array);
                            Console.WriteLine("Type the index you want to delete: ");
                            int indexToDelete = Convert.ToInt32(Console.ReadLine());
                            array = removeFromIndexDouble(array, indexToDelete);
                            preExitDouble(array);
                            break;
                        case 2:
                            //Remove from value
                            banner();
                            showDataDouble(array);
                            Console.WriteLine("Type the value you want to delete:");
                            double del = Convert.ToDouble(Console.ReadLine());

                            //Get the index from the element of the array
                            int index = Array.IndexOf(array, del);

                            //Remove the data from the array
                            array = removeFromIndexDouble(array, index);

                            preExitDouble(array);

                            break;
                        case 3:
                            //Remove all the data
                            banner();
                            Array.Clear(array, 0, array.Length);
                            showDataDouble(array);
                            preExitDouble(array);
                            break;
                        default:
                            Console.WriteLine("Enter a valid option!");
                            System.Threading.Thread.Sleep(500);
                            removeData(array);
                            break;
                    }
                }
                removeData(array);

                break;
            case 3:
                //See data
                showDataDouble(array);
                preExitDouble(array);
                break;
            case 4:
                //Update data
                void updateData(double[]array)
                {
                    banner();
                    Console.WriteLine("Update data");
                    Console.WriteLine("1 - Update from index");
                    Console.WriteLine("2 - Update from value");
                    Console.WriteLine("3 - Exit");
                    int opt = Convert.ToInt32(Console.ReadLine());

                    switch (opt)
                    {
                        case 1:
                            //Update from index
                            showDataDouble(array);
                            Console.WriteLine("Type the index you want to modify: ");
                            int indexMod = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Type the new value you want to enter: ");
                            double newValue = Convert.ToDouble(Console.ReadLine());

                            //Find the value in the array
                            for(int i = 0; i < array.Length; i++)
                            {
                                if(i == indexMod)
                                {
                                    array[i] = newValue;
                                    break;
                                }
                            }

                            //Show the results
                            showDataDouble(array);
                            Console.WriteLine("The array has been updated!");
                            preExitDouble(array);
                            break;
                        case 2:
                            //Update from value
                            showDataDouble(array);
                            Console.WriteLine("Type the value you want to modify:");
                            double valMod = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Type the new value you want to enter");
                            double newVal = Convert.ToDouble(Console.ReadLine());

                            //Search the value and obtain the index
                            int index = Array.IndexOf(array, valMod);

                            //Modify the value
                            array[index] = newVal;

                            showDataDouble(array);
                            Console.WriteLine("The array has been updated!");
                            preExitDouble(array);
                            break;
                        case 3:
                            //Exit
                            preExitDouble(array);
                            break;
                        default:
                            Console.WriteLine("Enter a valid option!");
                            updateData(array);
                            break;
                    }
                }

                updateData(array);

                break;
            case 5:
                //Exit
                exit();
                break;
            default:
                Console.WriteLine("Enter a valid option!");
                manageArrayDouble(array);
                break;

        }
    }

    //Array double functions
    static void showDataDouble(double[] array)
    {
        banner();
        for(int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Index: " + i + ", Value: " + array[i]);
        }
    }

    static void preExitDouble(double[] array)
    {
        //Ask if the user want to exit or to return to the menu
        Console.WriteLine("\nType M to go back to the menu");
        Console.WriteLine("Or type E to exit from the app");
        string input = Console.ReadLine();
        input = input.ToLower();

        if (input == "m")
        {
            //Go back to the menu
            manageArrayDouble(array);
            
        }
        else if (input == "e")
        {
            //Exit from app
            exit();
        }
    }

    static double[] removeFromIndexDouble(double[]array, int index)
    {
        //Shift elements position
        for(int i = index; i < array.Length-1; i++)
        {
            array[i] = array[i + 1];
        }

        //Resize array
        Array.Resize(ref array, array.Length - 1);

        //Show data with changes
        showDataDouble(array);

        return array;
    }

    static void manageArrayStr(string[] array)
    {
        banner();
        Console.WriteLine("What do you want to do: ");
        Console.WriteLine("1 - Add data to the array");
        Console.WriteLine("2 - Remove data from the array");
        Console.WriteLine("3 - See the data");
        Console.WriteLine("4 - Update the data");
        Console.WriteLine("5 - Exit");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                //Add data to the array
                void addData(string[]array)
                {
                    for(int i = 0; i < array.Length; i++)
                    {
                        banner();
                        int counter = i + 1;
                        Console.WriteLine(counter + " - Enter the word to put in the array: ");
                        string data = Console.ReadLine();
                        array[i] = data;
                    }
                    manageArrayStr(array);
                }

                addData(array);
                break;
            case 2:
                //Remove data from the array
                void removeData()
                {
                    banner();
                    Console.WriteLine("Remove data from the array");
                    Console.WriteLine("1 - Remove from index");
                    Console.WriteLine("2 - Remove from value");
                    Console.WriteLine("3 - Remove all data");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            //Remove from index
                            banner();
                            showDataStr(array);
                            Console.WriteLine("Type the index you want to delete:");
                            int indexToDelete = Convert.ToInt32(Console.ReadLine());
                            array = removeFromIndex(array, indexToDelete);
                            preExitStr(array);
                            break;
                        case 2:
                            //Remove from value
                            banner();
                            showDataStr(array);
                            Console.WriteLine("Type the value you want to delete:");
                            string del = Console.ReadLine();

                            //Get the index from the element
                            int index = Array.IndexOf(array, del);

                            //Remove the data from the array
                            array = removeFromIndex(array, index);

                            preExitStr(array);
                            break;
                        case 3:
                            //Remove all data
                            banner();
                            Array.Clear(array,0,array.Length);
                            showDataStr(array);
                            preExitStr(array);
                            break;
                        default:
                            banner();
                            Console.WriteLine("Enter a valid option!");
                            removeData();
                            break;


                    }
                }
                removeData();
                break;
            case 3:
                //See the data
                showDataStr(array);
                preExitStr(array);
                break;
            case 4:
                //Update the data
                updateDataStr(array);
                break;
            case 5:
                exit();
                break;
            default:
                Console.WriteLine("Enter a valid option!");
                manageArrayStr(array);
                break;
        }
    }

    //String array functions

    static void showDataStr(string[] array)
    {
        banner();
        for(int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Index: " + i + ", Value: " + array[i]);
        }
    }

    static void preExitStr(string[] array)
    {
        //Ask if the user want to exit or to return to the menu
        Console.WriteLine("\nType M to go back to the menu");
        Console.WriteLine("Or type E to exit from the app");
        string input = Console.ReadLine();
        input = input.ToLower();

        if(input == "m")
        {
            //Go back to the menu
            manageArrayStr(array);
        }
        else if(input == "e")
        {
            exit();
        }
    }

    static string[] removeFromIndex(string[]array, int index)
    {
        //Shift elements position
        for(int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        //Resize array
        Array.Resize(ref array, array.Length - 1);

        //Show the array with changes
        showDataStr(array);

        return array;
    }

    static string[] updateDataStr(string[] array)
    {
        banner();
        Console.WriteLine("1 - Update from index");
        Console.WriteLine("2 - Update from value");
        Console.WriteLine("3 - Exit");
        int opt = Convert.ToInt32(Console.ReadLine());

        switch (opt)
        {
            case 1:
                //Update from index
                showDataStr(array);
                Console.WriteLine("Type the index you want to modify:");
                int indexMod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the new value you want to enter");
                string newValue = Console.ReadLine();

                //Find the value in the array
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == indexMod)
                    {
                        array[i] = newValue;
                        break;
                    }
                }

                showDataStr(array);
                Console.WriteLine("The array has been updated!");
                preExitStr(array);
                break;
            case 2:
                //Update from value
                showDataStr(array);
                Console.WriteLine("Type the value you want to modify");
                string valueMod = Console.ReadLine();
                Console.WriteLine("Type the new value you want to enter:");
                string newVal = Console.ReadLine();

                //Search the value and obtain the index
                int index = Array.IndexOf(array, valueMod);

                //Modify and show
                array[index] = newVal;

                showDataStr(array);
                Console.WriteLine("The value has been updated!");
                preExitStr(array);
                break;
            case 3:
                //Exit
                manageArrayStr(array);
                break;
            default:
                Console.WriteLine("Enter a valid option!");
                System.Threading.Thread.Sleep(500);
                updateDataStr(array);
                break;
        }

        return array;
    }


}