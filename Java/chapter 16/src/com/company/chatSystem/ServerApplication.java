package com.company.chatSystem;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * Created by User on 22/11/2014.
 */
public class ServerApplication {
    public static void main(String args[])
    {
        InputStream inputStream;
        OutputStream outputStream;
        DataInputStream dataInputStream;
        DataOutputStream dataOutputStream;
        ServerSocket server = null;
        MessageBoard mb = new MessageBoard();
        try
        {
            server = new ServerSocket(1300,5);
        }
        catch(IOException e)
        {
        }
        Socket socket = null;
        ClientDescriptor client = null;
        ConnectionProxy connection = null;

        while(true)
        {
            try
            {
                socket = server.accept();
                connection = new ConnectionProxy(socket);
                client = new ClientDescriptor();
                connection.addConsumer(client);
                client.addConsumer(mb);
                mb.addConsumer(connection);
                connection.start();

            }
            catch(IOException e)
            {
            }
        }
    }}
