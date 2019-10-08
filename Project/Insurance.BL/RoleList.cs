namespace Insurance.BL
{
    /// <summary>
    /// Список ролей доступа.
    /// </summary>
    public enum RoleList
    {
        /// <summary>
        /// Не удается получить идентификатор.
        /// </summary>
        error = 0,

        /// <summary>
        /// Пользователь с ограниченными провами доступа.
        /// </summary>
        user = 1,

        /// <summary>
        /// Пользователь с расширенными правами пользователя.
        /// </summary>
        administrator = 2
    }
}
