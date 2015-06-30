package il.ac.hit.currencies

import java.util
import java.io._

class CurrenciesDataManager extends Serializable {

  var listData:util.List[Currency] = new util.LinkedList[Currency]
  var lastUpdate:String = ""

  def cleanData(path:String) = {
    var fileOutputStream: FileOutputStream = null
    var file: File = null
    try {
      file = new File(path)
      fileOutputStream = new FileOutputStream(file)
      fileOutputStream.write((new String).getBytes)
      fileOutputStream.close
      if (listData != null) {
        listData.clear()
      }
      lastUpdate = null
    }
    catch {case e:IOException => e.printStackTrace}
    finally {
      fileOutputStream.flush
      if(fileOutputStream != null)
        fileOutputStream.close
    }
  }

  def writeData(path:String) = {
    var fileOutputStream: FileOutputStream = null
    var objectOutputStream: ObjectOutputStream = null
    var file: File = null

    try {
      file = new File(path)
      fileOutputStream = new FileOutputStream(file)
      objectOutputStream = new ObjectOutputStream(fileOutputStream)
      objectOutputStream.writeObject(listData)
    }
    catch {case e:IOException => e.printStackTrace}
    finally {
      objectOutputStream.flush
      if(objectOutputStream != null)
        objectOutputStream.close
      fileOutputStream.flush
      if(fileOutputStream != null)
        fileOutputStream.close
    }
  }
  def getLastUpdate = lastUpdate
}
