package com.company.Ex13;

/**
 * The following application should receive two arguments via the command line.
 * The first should be the name of a folder that already exists and the second should be a new name.
 * The application should copy the folder that already exists (as well as all files and all folders it includes)
 * and name the new copy with the new name (the second argument).
 * You should complete the missing code.
 */
import java.io.*;

public class CopyMethods
{
    public static void main(String[] args)
    {
        try
        {
            copyDirectory(new File(args[0]),new File(args[1]));
        }
        catch(IOException e)
        {
            System.out.println("The directory copy has failed.");
            e.printStackTrace();
        }
    }

    public static void copyFile(File src, File dst) throws IOException
    {
        InputStream in = null;
        OutputStream out = null;
        try
        {
            in = new FileInputStream(src);
            out = new FileOutputStream(dst);
            byte[] buf = new byte[10*1024];
            int length;
            while ((length = in.read(buf)) > 0)
            {
                out.write(buf, 0, length);
            }
        }
        finally
        {
            if(in!=null)
            {
                try
                {
                    in.close();
                }
                catch(Exception e)
                {
                    e.printStackTrace();
                }
            }
            if(out!=null)
            {
                try
                {
                    out.close();
                }
                catch(Exception e)
                {
                    e.printStackTrace();
                }
            }
        }
    }

    public static void copyDirectory(File src, File dst) throws IOException
    {
        if (src.isDirectory())
        {
            if (!dst.exists())
            {
                dst.mkdir();
            }
            File[] childrenFiles = src.listFiles();
            for (int i = 0; i < childrenFiles.length; i++)
            {
                copyDirectory(childrenFiles[i],
                        new File(dst, childrenFiles[i].getName()));
            }
        }
        else
        {
            copyFile(src, dst);
        }
    }
}

