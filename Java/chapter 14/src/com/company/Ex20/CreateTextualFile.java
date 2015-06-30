package com.company.Ex20;

/**
 * The following application should receive via args (via the command line) two arguments.
 * The first is a name of a file. The second is a string we want to write into that file. If the file doesn't exist the application automatically creates it.

 You should complete the missing code.
 */
import java.io.*;

public class CreateTextualFile
{
    public static void main(String[] args)
    {
        BufferedWriter bw = null;
        FileWriter fw = null;
        try
        {
            fw = new FileWriter(args[0]);
            bw = new BufferedWriter(fw);
            bw.write(args[1]);
            bw.flush();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(fw!=null)
            {
                try
                {
                    fw.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
            if(bw!=null)
            {
                try
                {
                    bw.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
        }
    }
}
