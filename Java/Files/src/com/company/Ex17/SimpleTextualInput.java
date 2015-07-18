package com.company.Ex17;

/**
 * The following example should receive a textual input from the user and prints it out to the screen.
 * You should complete the missing code.
 */
import java.io.*;

public class SimpleTextualInput
{
    public static void main(String[] args)
    {
        BufferedReader br = null;
        InputStreamReader isr = null;
        try
        {
            isr = new InputStreamReader(System.in);
            br = new BufferedReader(isr);
            String str = null;
            str = br.readLine();
            System.out.println("The entered text is \"" + str + "\"");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(isr!=null)
            {
                try
                {
                    isr.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
            if(br!=null)
            {
                try
                {
                    br.close();
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }
            }
        }
    }
}
