import useAuth from '../hooks/useAuth';
import { Navigate, Outlet } from 'react-router-dom';

type Props = {
    role: string;
    redirectPath: string;
};

const AuthorizedRoute = ({ role, redirectPath }: Props) => {
    const { authAccount, isTokenExpired } = useAuth();

    // if (isLoading) {
    //     return null;
    // }

    // if (isError) {
    //     return <div className="text-red-600">Error</div>
    // }

    const isAuthorized: boolean = (!!authAccount && authAccount.role.toLowerCase() === role.toLowerCase());

    console.log(`Is authorized: ${isAuthorized}`);

    return (
        isAuthorized ? <Outlet /> : <Navigate to={isTokenExpired ? '/login' : redirectPath} />
    );
};

export default AuthorizedRoute;