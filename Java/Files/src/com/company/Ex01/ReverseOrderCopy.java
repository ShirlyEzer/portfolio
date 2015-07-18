package com.company.Ex01;

import java.io.*;


/**
 * Develop an application that receives the names of two files and copy the content of the first one into the second
 * (overwriting it in a reverse bytes order).
 */
public class ReverseOrderCopy {

    public static void main(String[] args) {

        if(args.length != 2) {
            System.out.println("Invalid input arguments");
        }
        else {
            Reverse(args[0], args[1]);
        }
    }

    public static void Reverse(String destination, String source)
    {
        File f = new File(source);
        int size = (int)f.length();
        byte[] bytes = new byte[size];

        FileInputStream file2 = null;
        FileOutputStream file1 = null;

        try {
            file2 = new FileInputStream(source); // source
            file1 = new FileOutputStream(destination); // destination

            if (file2.read(bytes) == 0) {
                System.out.println("The file is empty");
            }
            else {
                for (int i = size - 1; i >= 0; i--) {
                    file1.write(bytes[i]);
                }
                System.out.println("Good");
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        catch (IOException e)
        {
            System.out.println("could not read or write to file");
        }
        finally {
            //file1.close();
            if (file1 != null)
            {
                try {
                    file1.close();
                }
                catch (IOException e)
                {
                    System.out.println(e.getMessage());
                }
            }
            //file2.close();
            if (file2 != null)
            {
                try {
                    file2.close();
                }
                catch (IOException e)
                {
                    System.out.println(e.getMessage());
                }
            }
        }
    }
}
