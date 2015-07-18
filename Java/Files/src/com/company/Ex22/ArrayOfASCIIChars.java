package com.company.Ex22;

/**
 * The following application should store all characters in the range of 32 and 127 within an array together
 * with the required additional characters so that when the array is dumped to the screen a tab space will be printed out
 * between each one of them and a new line will start every 10 characters.
 * You should complete the missing code.
 */
import java.io.*;

public class ArrayOfASCIIChars
{
    public static void main(String[] args)
    {
        byte[] b = new byte[(127 - 32 + 1)*2];
        int index = 0;
        for (int i = 32; i < 127; i++)
        {
            b[index++] = (byte) i;
            if ((i-2) % 10 == 0)
                b[index++] = (byte) '\n';
            else
                b[index++] = (byte) '\t';
        }
        b[index++] = (byte) '\n';
        try
        {
            System.out.write(b);
        }
        catch (IOException e)
        {
            System.err.println(e);
        }
    }
}
