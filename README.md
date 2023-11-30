# ATM Console Application

This simple console application represents an ATM (Automated Teller Machine) with basic functionalities such as withdrawal, deposit, balance inquiry, and end-of-day operations. The application utilizes C# and demonstrates the use of dictionaries, lists, file I/O, and basic console input/output.

## How to Use

To run the ATM application, follow these steps:

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/your-username/ATM-Console-App.git
   ```

2. Open the project in your preferred C# development environment.

3. Build and run the application.

4. Follow the on-screen instructions to perform various ATM transactions.

## Features

1. **Withdrawal:**
   - Users can withdraw funds from their accounts.
   - Validates the user and ensures the withdrawal amount is valid.

2. **Deposit:**
   - Users can deposit funds into their accounts.
   - Validates the user and ensures the deposit amount is valid.

3. **Balance Inquiry:**
   - Users can check their account balance.
   - Validates the user before displaying the balance.

4. **End-of-Day Operations:**
   - View transaction logs.
   - View and write fraud logs to a file.
   - Return to the main menu.

## Code Structure

- The `ATM` class contains the main logic for handling user interactions and transactions.
- The `Program` class contains the `Main` method to initialize and run the ATM.

## Transaction Log

- All transactions are logged with a timestamp in the `transactionLog` list.
- The transaction log can be viewed during end-of-day operations.

## Fraud Log

- The application identifies and logs invalid user actions (e.g., invalid account numbers) as potential fraud.
- Fraud logs are displayed and written to a file during end-of-day operations.

## File Structure

- `TransactionLog.txt`: Stores the transaction log.
- `EOD_DDMMYYYY.txt`: Stores the fraud log for the respective day during end-of-day operations.

## Contributing

If you find any issues or have suggestions for improvements, please feel free to contribute by creating issues or pull requests.

Thank you for using the ATM Console Application!

<img width="740" alt="Ekran Resmi 2023-11-27 ÖS 6 46 39" src="https://github.com/sevketugurel/ATM-Uygulamasi/assets/118289177/5546ed21-fa31-4d21-9ba5-57325f49f9bb">
