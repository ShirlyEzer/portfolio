package com.samples;

/**
 * Created by User on 18/11/2014.
 */
import java.lang.Exception;
import java.net.*;
import java.io.*;
import java.util.*;
public class TCPParallelServer {

    public static void main(String[] args) {
        TCPParallelServerImp ps = new TCPParallelServerImp();
        try {
            ps.go();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
