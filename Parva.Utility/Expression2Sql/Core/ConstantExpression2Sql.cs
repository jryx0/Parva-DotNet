﻿ 
using System.Linq.Expressions;

namespace Parva.Utility.Expression2Sql
{
	class ConstantExpression2Sql : BaseExpression2Sql<ConstantExpression>
	{
		protected override SqlPack Where(ConstantExpression expression, SqlPack sqlPack)
		{
			sqlPack.AddDbParameter(expression.Value);
			return sqlPack;
		}

		protected override SqlPack In(ConstantExpression expression, SqlPack sqlPack)
		{
			if (expression.Type.Name == "String")
			{
				sqlPack.Sql.AppendFormat("'{0}',", expression.Value);
			}
			else
			{
				sqlPack.Sql.AppendFormat("{0},", expression.Value);
			}
			return sqlPack;
		}
	}
}