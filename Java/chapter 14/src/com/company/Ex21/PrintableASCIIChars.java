package com.company.Ex21;

/**
 * The following application should print out to the screen all character in between the range 32 and 127.
 * You should complete the missing code.
 */
public class PrintableASCIIChars
{
    public static void main(String[] args)
    {
        for (int i = 32; i < 127; i++)
        {
            System.out.write(i);
            if (i % 7 == 0)
                System.out.write('\n');
            else
                System.out.write('\t');
        }
        System.out.write('\n');
    }
}
