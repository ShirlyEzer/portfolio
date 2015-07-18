package com.company.Ex19;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;

public class FileToBytes
{
    public static void main(String[] args)
    {
        try
        {
            File file = new File(args[0]);
            byte vec[] = null;
            vec = convertFileToBytes(file);
            for (int i = 0; i < vec.length; i++)
            {
                System.out.println("byte num." + i + " is " + vec[i]);
            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    public static byte[] convertFileToBytes(File file) throws IOException,
            FileTooBigException
    {
        InputStream is = null;
        try
        {
            is = new FileInputStream(file);
            long length = file.length();
            if (length > Integer.MAX_VALUE)
            {
                throw new FileTooBigException(length
                        + " bytes file size is too big to handle");
            }
            byte[] bytes = new byte[(int)length];
            int offset = 0;
            int numRead = 0;
            numRead = is.read(bytes, offset, bytes.length - offset);
            do
            {
                offset += numRead;
                numRead = is.read(bytes, offset, bytes.length - offset);
            }
            while (offset<bytes.length && numRead>=0);
            return bytes;
        }
        finally
        {
            if (is != null)
            {
                try
                {
                    is.close();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
        }

    }
}

