package com.company.Ex03;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/**
 * Develop a Java application that receives the name of a CSV file that includes data about content titles sales
 * for mobile telephones.
 * The CSV includes 3 data items in each row (title name, fee per download & number of downloads).
 * The Java application you develop should calculate the total sales based on the CSV file it receives.
 * The total sales is the total of all titles' sales.
 * The sales of each title is calculated by multiplying the number of downloads with fee per download.
 * Please note that each title has a different fee per download.
 */
public class SimpleCSVFileProcess {
    public static void main(String[] args) {

        int sum = 0;
        int feePerDownload = 0;
        int numberOfDownloads = 0;

        if (args.length != 1)
        {
            System.out.println("Invalid input arguments");
        }

        else
        {
            BufferedReader br = null;
            String line = null;
            try {
                br = new BufferedReader(new FileReader(args[0]));
                while ((line = br.readLine()) != null)
                {
                    String[] info = line.split(",");
                    feePerDownload = Integer.getInteger(info[1]);
                    numberOfDownloads = Integer.getInteger(info[2]);
                    sum += feePerDownload*numberOfDownloads;
                }
            }
            catch (FileNotFoundException e)
            {
                System.out.println(e.getMessage());
            }
            catch (IOException e)
            {
                System.out.println(e.getMessage());
            }
        }
    }
}
