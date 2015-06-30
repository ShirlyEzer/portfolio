package com.company.Ex05;

import java.io.*;

/**
 *Declare a class that describes a banking account.
 * An object instantiated from that class should include an automatic logging capability that
 * writes to a file log each time a deposit or withdraw takes place.
 * Each line in that log file should include the exact time stamd (date&hour) in which the withdraw/deposit took place
 * and the exact sum (you can denote a deposit with a positive sum and a withdraw with a negative one).
 */
public class BankAccount {
    private double balance;
    private long id;
    private String name;
    FileWriter fileWriter;

    public BankAccount(double balance, long id, String name) {
        this.balance = balance;
        this.id = id;
        this.name = name;
        try {
            fileWriter = new FileWriter(Long.toString(id));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void deposit(double amount) //+
    {
        balance += amount;

        try {
            fileWriter.write("deposit : " + id + " " + name + " " + balance + "\n");
            fileWriter.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void withdraw(double amount) //-
    {
        balance -= amount;

        try {
            fileWriter.write("withdraw : " + id + " " + name + " " + balance + "\n");
            fileWriter.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
