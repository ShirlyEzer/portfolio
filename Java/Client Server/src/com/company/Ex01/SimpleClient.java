package com.company.Ex01;

/**
 * Created by User on 17/11/2014.
 */
import java.net.*;
import java.io.*;

public class SimpleClient {
    public static String serverName = "127.0.0.1";
    public static int serverPort = 1300;

    public static void main(String[] args) {
        Socket socket = null;
        InputStream is = null;
        DataInputStream dis = null;
        OutputStream os = null;
        DataOutputStream dos = null;
        try {
            socket = new Socket(serverName,serverPort);
            System.out.println("socket is created...");
            while (true) {
                is = socket.getInputStream();
                System.out.println("input stream was created");
                dis = new DataInputStream(is);
                System.out.println("data input stream was created");
                os = socket.getOutputStream();
                System.out.println("output stream was created");
                dos = new DataOutputStream(os);
                System.out.println("data output stream was created");
                dos.writeUTF(args[0]);
                System.out.println(args[0] + " was written to server");
                System.out.println(dis.readUTF() + " was received back from server");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (is != null) {
                try {
                    is.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (os != null) {
                try {
                    os.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (dos != null) {
                try {
                    dos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (dis != null) {
                try {
                    dis.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (socket != null) {
                try {
                    socket.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

    }
}

