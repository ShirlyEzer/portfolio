package com.company.Ex14;

/**
 * The following application should delete the directory its name it receives as an argument via the command line.
 * The deletion should include all files and all sub directories the directory includes.
 */
import java.io.*;

public class DeleteDirectory
{
    public static void main(String[] args)
    {
        if(DeleteDirectory.deleteDir(new File(args[0])))
        {
            System.out.println("The directory was successfully deleted.");
        }
        else
        {
            System.out.println("The directory wasn't deleted");
        }
    }

    public static boolean deleteDir(File file)
    {
        if (file.isDirectory())
        {
            String[] children = file.list();
            for (int i = 0; i < children.length; i++)
            {
                boolean success = deleteDir(new File(file, children[i]));
                if (!success)
                {
                    return false;
                }
            }
        }
        return file.delete();
    }
}


