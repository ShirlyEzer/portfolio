package com.company.Ex05;

/**
 * Created by User on 11/11/2014.
 */
public class BankAccountDemo {
    public static void main(String[] args) {

        BankAccount b1 = new BankAccount(100, 123456789, "Moshe");
        b1.deposit(100);
        b1.withdraw(200);
    }
}
