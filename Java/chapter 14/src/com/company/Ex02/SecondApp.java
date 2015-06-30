package com.company.Ex02;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

/**
 * The second application will receive through the command line a student id and then it will look for the appropriate
 * file (in the same folder), retrieve the instance that was serialized into that file,
 * and prints its attributes values to the screen.
 */
public class SecondApp {

    public static void main(String[] args) {
        if (args.length != 1)
        {
            System.out.println("Invalid input arguments");
        }
        else {
            try {
                Student student = null;
                FileInputStream f = new FileInputStream(args[0]);
                ObjectInputStream ois = new ObjectInputStream(f);
                student = (Student) ois.readObject();
                System.out.println(student);
                ois.close();
                f.close();
            } catch (IOException e) {

            } catch (ClassNotFoundException e) {

            }
        }
    }

}
