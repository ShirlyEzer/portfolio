package com.company.Ex24;

/**
 * Created by User on 12/11/2014.
 */
import java.io.*;
import javax.swing.*;

public class JStreamedTextArea extends JTextArea
{
    public static final long serialVersionUID = 123;

    OutputStream output = new JTextAreaOutputStream();

    public JStreamedTextArea()
    {
        this("");
    }

    public JStreamedTextArea(String text)
    {
        super(text);
    }

    public OutputStream getOutputStream()
    {
        return output;
    }

    class JTextAreaOutputStream extends OutputStream
    {
        public synchronized void write(int b)
        {
            //Taking away irrelevant bytes
            b &= 0x000000FF;
            char c = (char) b;
            append(Character.toString(c));
        }
        public synchronized void write(byte[] b, int offset, int length)
        {
            append(new String(b,offset,length));
        }
    }

    public static void main(String args[])
    {
        if(args.length!=1)
        {
            System.out.println("You should pass a file name via the command line");
        }
        else
        {
            InputStream input = null;
            OutputStream output = null;
            try
            {
                JFrame frame = new JFrame("Simple JStreamTextArea Demo");
                JStreamedTextArea textArea = new JStreamedTextArea();
                output = textArea.getOutputStream();
                frame.add(new JScrollPane(textArea));
                frame.setSize(600,400);
                frame.setVisible(true);
                input = new FileInputStream(args[0]);
                IOUtils.streamCopy(input,output);
            }
            catch(IOException e)
            {
                e.printStackTrace();
            }
            finally
            {
                if(output!=null)
                {
                    try {output.close();} catch(IOException e){}
                }
                if(input!=null)
                {
                    try{input.close();} catch(IOException e){}
                }
            }
        }
    }
}
