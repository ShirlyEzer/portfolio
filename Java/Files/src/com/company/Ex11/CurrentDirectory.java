package com.company.Ex11;

/**
 * The following application should print out the path of the current working directory.
 * The current working directory is the location in the file system from where the java command was invoked.
 * You should complete the missing code.
 */
import java.io.*;

public class CurrentDirectory
{
    public static void main(String[] args)
    {
        String currentDirectory = System.getProperty("user.dir");
        System.out.println("The current directory is " + currentDirectory);
    }
}
