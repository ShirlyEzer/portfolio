package il.ac.hit.currencies;

/**
 * <code>CurrenciesPlatformException</code> represents an Exception in the Currencies Application.
 *
 *  @author Shirly
 *  @author Oreyan
 */
public class CurrenciesPlatformException extends Exception {

    public CurrenciesPlatformException(String description) {
        super(description);
    }

    public CurrenciesPlatformException(String message, Throwable cause) {
        super(message, cause);
    }
}
