import React, { useEffect, useState } from 'react'
import './SidebarNav.css';
import MenuIcon from '@mui/icons-material/Menu';
type Props = {}

const SidebarNav = (props: Props) => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleSidebar = () => setIsOpen(!isOpen);

    // Close sidebar on window resize
    useEffect(() => {
        const handleResize = () => {
            if (window.innerWidth < 768) {
                setIsOpen(false);
            }
        };

        window.addEventListener('resize', handleResize);

        // Cleanup
        return () => window.removeEventListener('resize', handleResize);
    }, []);

    return (
        <div className='shadow-lg'>
            <button className="sidebar-toggle bg-black px-3 rounded-md text-white" onClick={toggleSidebar}>
                <MenuIcon/>
            </button>
            <div className={`sidebar ${isOpen ? 'open' : ''}`}>
                <a href="">Thống kê</a>
                <a href="">Đăng nhập</a>
                <a href="">Đăng xuất</a>
            </div>
        </div>
    );
};

export default SidebarNav;