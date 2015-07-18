package com.company.chatSystem;

import java.io.*;
import java.net.Socket;

/**
 * Created by User on 22/11/2014.
 */
public class ConnectionProxy extends Thread implements StringConsumer, StringProducer {

    private InputStream inputStream;
    private OutputStream outputStream;
    private DataInputStream dataInputStream;
    private DataOutputStream dataOutputStream;
    private StringConsumer consumer;
    private Socket socket; //this is client's socket

    public ConnectionProxy(Socket socket)
    {
        this.socket = socket;
        try {
            inputStream = socket.getInputStream();
            outputStream = socket.getOutputStream();
        } catch (IOException e) {
            e.printStackTrace();
        }
        dataInputStream = new DataInputStream(inputStream);
        dataOutputStream = new DataOutputStream(outputStream);
    }

    @Override
    public void run() {
        super.run();

        while(socket.isClosed() == false)
        {
            try {
                String message = dataInputStream.readUTF();
                consumer.consume(message);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public void consume(String message) {
        try {
            dataOutputStream.writeUTF(message);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addConsumer(StringConsumer sc) {
        this.consumer = sc;
    }

    @Override
    public void removeConsumer(StringConsumer sc) {
        try {
            dataInputStream.close();
            dataOutputStream.close();
            inputStream.close();
            outputStream.close();
            socket.close();
            ((StringProducer)consumer).removeConsumer(sc);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
