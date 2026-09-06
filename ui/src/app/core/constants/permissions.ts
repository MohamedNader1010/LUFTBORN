export const Permissions = {
    User: {
        Create: 'User.Create',
        Delete: 'User.Delete',
        Get: 'User.Read',
        Update: 'User.Update'
    }
} as const;

export type PermissionValue = typeof Permissions.User[keyof typeof Permissions.User];

export type UserPermissions = {
    Create: typeof Permissions.User.Create;
    Delete: typeof Permissions.User.Delete;
    Get: typeof Permissions.User.Get;
    Update: typeof Permissions.User.Update;
};