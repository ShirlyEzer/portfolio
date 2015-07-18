package com.company.Ex06;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * Develop an application that is capable of reading from the encrypted file (that was created using the other application)
 * and writing the original letters into a new text file.
 */
public class FilesDecryption {
    public static void main(String[] args) {
        int number = 0;
        byte[] bytes = null;
        FileInputStream originalFile = null;
        FileOutputStream decryptedFile = null;
        int length = 0;

        if (args.length != 3) {
            System.out.println("Invalid input arguments");
        }
        else {
            try {
                number = Integer.parseInt(args[2]);
                originalFile = new FileInputStream(args[0]);
                decryptedFile = new FileOutputStream(args[1]);
                bytes = new byte[100];
                length = originalFile.read(bytes);

                while (length != 0){
                    for(byte b : bytes)
                    {
                        b -= number;
                    }

                    decryptedFile.write(bytes);
                    length = originalFile.read(bytes);
                }
                decryptedFile.flush();
            } catch (NumberFormatException e) {
                e.printStackTrace();
            } catch (IOException e){
                System.out.println(e.getMessage());
            }
            finally {
                if (originalFile != null) {
                    try {
                        originalFile.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
                if (decryptedFile != null) {
                    try {
                        decryptedFile.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
    }
}
