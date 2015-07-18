package com.company.Ex19;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;

public class FileTooBigException extends IOException
{
    public final static long serialVersionUID = 1;
    public FileTooBigException()
    {
    }
    public FileTooBigException(String arg0)
    {
        super(arg0);
    }
    public FileTooBigException(Throwable arg0)
    {
        super(arg0);
    }
    public FileTooBigException(String arg0, Throwable arg1)
    {
        super(arg0, arg1);
    }
}

