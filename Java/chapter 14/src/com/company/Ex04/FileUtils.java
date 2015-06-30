package com.company.Ex04;

import java.io.*;

/**
 * Created by User on 11/11/2014.
 */
public class FileUtils {

    public static void copyFiles(File destinationFolder, File file)
    {
        File destinationFile = null; // creating the file who will get the copy
        FileInputStream fileInputStream = null; // creating input stream from the file copied
        FileOutputStream fileOutputStream = null; // creating output stream for the destination file
        try {
            fileInputStream = new FileInputStream(file);
            destinationFile = new File(destinationFolder, file.getName());
            fileOutputStream = new FileOutputStream(destinationFile);

            byte[] copy = new byte[500];
            int num = fileInputStream.read(copy);

            while (num != -1)
            {
                fileOutputStream.write(copy);
                num = fileInputStream.read(copy);
            }
        }
        catch (FileNotFoundException e)
        {
            System.out.println(e.getMessage());
        }
        catch (IOException e)
        {
            System.out.println(e.getMessage());
        }
        finally {
            if (fileInputStream != null)
            {
                try {
                    fileInputStream.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (fileOutputStream != null)
            {
                try {
                    fileOutputStream.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
