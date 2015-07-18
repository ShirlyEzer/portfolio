package com.company.Ex23;

/**
 * The following application should receive two filenames and copy
 * the content of the first into the second (overidding its content).
 * You should complete the missing code.
 */
import java.io.*;

public class IOUtils
{
    public static void streamCopy(
            InputStream in,
            OutputStream out) throws IOException
    {
        synchronized(out)
        {
            synchronized(in)
            {
                byte vec[] = new byte[256];
                int numOfBytes = in.read(vec);
                while(numOfBytes!=0)
                {
                    out.write(vec,0,numOfBytes);
                    numOfBytes = in.read(vec);
                }
            }
        }
    }
}

