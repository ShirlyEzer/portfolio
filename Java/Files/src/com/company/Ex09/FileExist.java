package com.company.Ex09;

/**
 * The following application should check whether the file, its pathname it receives via the command line, exists or doesn't.
 * You should complete the missing code.
 */
import java.io.*;

public class FileExist
{
    public static void main(String[] args)
    {
        String filePath = args[0];
        File fileObject = new File(filePath);
        boolean exist = fileObject.exists();
        if(exist)
        {
            System.out.println("The file " + filePath + " exists.");
        }
        else
        {
            System.out.println("The file " + filePath + " doesn't exist.");
        }
    }
}
