using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Dynamic
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// <code>
    ///     var predicate = PredicateBuilder.True<TradeReportBES>();
    ///     var datasource = gvPending.DataSource as List<TradeReportBES>;
    /// 
    ///     if (trader.IsNotNull())
    ///     {
    ///         predicate = predicate.And(e => e.Trader.IsEqual(trader));
    ///     }
    ///
    ///     if (symbol.IsNotNull())
    ///     {
    ///         predicate = predicate.And(e => e.Symbol.IsEqual(symbol));
    ///     }
    ///
    ///     if (order.IsNotNull())
    ///     {
    ///         predicate = predicate.And(e => e.OrderID.IsEqual(order));
    ///     }
    ///
    ///     var filtered = datasource.AsQueryable().Where(predicate);
    /// </code>
    /// </example>
    public static class PredicateBuilder
    {
        #region| Properties |

        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        #endregion

        #region| Methods |

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        } 

        #endregion
    }
}
