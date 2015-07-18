package com.company.Ex18;

/**
 * The following application reads the textual content of a file its name is passed via the args array.
 * The application reads the file and prints out to the screen each line it reads.

 You should complete the missing code
 */
import java.io.*;

public class SimpleFileReader
{
    public static void main(String[] args)
    {
        FileReader fr = null;
        BufferedReader in = null;
        try
        {
            fr = new FileReader(args[0]);
            in = new BufferedReader(fr);
            String str = in.readLine();
            while (str != null)
            {
                System.out.println("==> "+str);
                str = in.readLine();
            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(in!=null)
            {
                try
                {
                    in.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
            if(fr!=null)
            {
                try
                {
                    fr.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
        }
    }
}
