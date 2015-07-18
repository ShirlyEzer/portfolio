package com.company.Ex15;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;

public class SimpleList
{
    public static void main(String[] args)
    {
        list(new File(args[0]));
    }

    public static void list(File file)
    {
        if(file.isFile())
        {
            System.out.println("You should pass a directory name... not a file name.");
        }
        else if(file.isDirectory())
        {
            String[] children = file.list();
            for(int i=0; i<children.length; i++)
            {
                System.out.println(children[i]);
            }
        }
    }
}
