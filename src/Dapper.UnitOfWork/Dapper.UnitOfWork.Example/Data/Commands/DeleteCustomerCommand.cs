﻿using System.Data;

namespace Dapper.UnitOfWork.Example.Data.Commands
{
    public class DeleteCustomerCommand : ICommand
    {
        private const string Sql = @"
			DELETE
				Customers
			WHERE
				CustomerID = @customerId
		";

        private readonly string _customerId;

        // Set this to true prevents invoking the command without an explicit transaction
        public bool RequiresTransaction => false;

        public DeleteCustomerCommand(string customerId)
            => _customerId = customerId;

        // this is pure Dapper code
        public void Execute(IDbConnection connection, IDbTransaction transaction)
            => connection.Execute(Sql, new
            {
                customerId = _customerId
            }, transaction);
    }
}
