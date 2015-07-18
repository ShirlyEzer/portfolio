package com.company.Ex02;

import java.io.*;


/**
 * The first application will receive through the command line the five values and instantiate the class Student
 * with these values and save the new instance in a file which its name is the id value.
 */
public class FirstApp {
    public static void main(String[] args) {
        if (args.length != 5)
        {
            System.out.println("Invalid input arguments");
        }
else {
            try {
                Student student = new Student(args[0], args[1], Long.parseLong(args[2]), args[3], Double.parseDouble(args[4]));
                FileOutputStream f = new FileOutputStream(args[2]);
                ObjectOutputStream oos = new ObjectOutputStream(f);
                oos.writeObject(student);
                oos.close();
                f.close();

            } catch (NumberFormatException e) {
                System.out.println(e.getMessage());
            } catch (FileNotFoundException e) {
                System.out.println(e.getMessage());
            } catch (IOException e) {
                System.out.println(e.getMessage());
            }


        }
    }
}
