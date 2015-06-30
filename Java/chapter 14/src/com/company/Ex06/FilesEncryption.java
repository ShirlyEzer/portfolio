package com.company.Ex06;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * Assume a given text file (english ascii letters only) you need to encrypt into another file by adding a simple number
 * (between 0 & 9) to each one of the bytes. the app gets 3 arguments.
 * Develop an application that is capable of copying from one file into another (while encrypting all byes).
 */
public class FilesEncryption {
    public static void main(String[] args) {

        int number = 0;
        FileInputStream originalFile = null;
        FileOutputStream encryptedFile = null;
        byte[] bytes = null;
        int length = 0;

        if (args.length != 3)
        {
            System.out.println("Invalid input arguments");
        }
        else
        {
            try {
                number = Integer.parseInt(args[2]);
                originalFile = new FileInputStream(args[0]);
                encryptedFile = new FileOutputStream(args[1]);
                bytes = new byte[100];
                length = originalFile.read(bytes);

                while (length != 0)
                {
                    for (byte b : bytes)
                    {
                        b += number;
                    }
                    encryptedFile.write(bytes);
                    length = originalFile.read(bytes);
                }
                encryptedFile.flush();
            } catch (NumberFormatException e) {
                e.printStackTrace();
            } catch (IOException e)
            {
                System.out.println(e.getMessage());
            }
            finally {
                if(originalFile != null)
                {
                    try {
                        originalFile.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
                if (encryptedFile != null)
                {
                    try {
                        encryptedFile.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
    }
}
