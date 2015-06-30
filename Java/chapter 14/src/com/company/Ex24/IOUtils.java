package com.company.Ex24;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;

public class IOUtils
{
    public static void streamCopy(InputStream in, OutputStream out) throws IOException
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
