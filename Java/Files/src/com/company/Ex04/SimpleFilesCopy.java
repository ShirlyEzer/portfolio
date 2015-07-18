package com.company.Ex04;

import java.io.File;

/**
 * Develop a Java application that receives a name of a folder that includes images files and sorts these files
 * according to their files format (all JPG images are moved to a sub folder named "jpg",
 * all GIF images are moved to a sub folder named "gif" etc...).
 * Assume that in our world the available graphics formats are jpg, gif, png & bmp only.
 */
public class SimpleFilesCopy {

    public static void main(String[] args) {

        if(args.length != 1)
        {
            System.out.println("Invalid input arguments");
        }
        else {
            File folder = new File(args[0]);
            File[] files = folder.listFiles();

            File folderJPG = new File(args[0]+ "/jpg");
            folderJPG.mkdirs();
            File folderGIF = new File(args[0]+ "/gif");
            folderGIF.mkdirs();
            File folderPNG = new File(args[0]+ "/png");
            folderPNG.mkdirs();
            File folderBMP = new File(args[0]+ "/bmp");
            folderBMP.mkdirs();

            for (int i = 0; i < files.length; i++) {
                String fileName = files[i].getName();

                if (fileName.endsWith("jpg"))
                {
                    FileUtils.copyFiles(folderJPG,files[i]);
                }
                if (fileName.endsWith("gif"))
                {
                    FileUtils.copyFiles(folderGIF,files[i]);
                }
                if (fileName.endsWith("png"))
                {
                    FileUtils.copyFiles(folderPNG,files[i]);
                }
                if (fileName.endsWith("bmp"))
                {
                    FileUtils.copyFiles(folderBMP,files[i]);
                }
            }
        }
    }
}
