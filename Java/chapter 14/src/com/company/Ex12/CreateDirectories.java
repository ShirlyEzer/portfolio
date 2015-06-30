package com.company.Ex12;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;

public class CreateDirectories
{
    public static void main(String[] args)
    {
        File file = new File(args[0]);
        boolean succeeded = file.isDirectory();
        if(succeeded)
        {
            System.out.println("The directories were successfully created");
        }
        else
        {
            System.out.println("The directories were not created");
        }
    }
}
