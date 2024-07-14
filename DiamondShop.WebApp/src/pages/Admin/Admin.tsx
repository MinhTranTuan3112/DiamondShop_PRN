import React, { useEffect, useState } from "react";
import {
  PieChartOutlined,
  AppstoreOutlined,
  CrownOutlined,
  ShoppingCartOutlined,
  UserOutlined,
  LogoutOutlined,
} from "@ant-design/icons";
import type { MenuProps } from "antd";
import { Layout, Menu, theme } from "antd";
import Dashboard from "./Dashboard";
import DiamondManagement from "./DiamondManagement";
import OrderManagement from "./OrderManagement";
import ProductManagement from "./ProductManagement";
// import PromotionManagement from "./PromotionManagement";
import AccountManagement from "./AccountManagement";
import { fetchWhoAmI } from "../../services/auth_service";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";
import { AuthAccount } from "../../types/account";

const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>["items"][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[]
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem("Dashboard", "1", <PieChartOutlined />),
  getItem("Products", "2", <AppstoreOutlined />),
  getItem("Diamonds", "3", <CrownOutlined />),
  getItem("Orders", "4", <ShoppingCartOutlined />),
  getItem("Promotions", "5", <ShoppingCartOutlined />),
  getItem("Account Management", "6", <UserOutlined />),
  getItem("Logout", "7", <LogoutOutlined />),
];

const Admin: React.FC = () => {
  const { accessToken, logout } = useAuth();
  const navigate = useNavigate();
  const [collapsed, setCollapsed] = useState(false);
  const [selectedKey, setSelectedKey] = useState("1");
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  useEffect(() => {
    const handleAuth = async () => {
      const userInfoResponse = await fetchWhoAmI(accessToken);
      if (userInfoResponse.ok) {
        const userInfo: AuthAccount = await userInfoResponse.json();
        const userRole = userInfo.role;
        if (userRole === "Customer") {
          navigate("/");
        } else {
          navigate("/dashboard");
        }
      }
    };

    handleAuth();
  }, [accessToken, navigate]);

  const handleMenuClick: MenuProps["onClick"] = (e) => {
    if (e.key === "7") {
      logout();
    }
    setSelectedKey(e.key);
  };

  const renderContent = () => {
    switch (selectedKey) {
      case "1":
        return <Dashboard />;
      case "2":
        return <ProductManagement />;
      case "3":
        return <DiamondManagement />;
      case "4":
        return <OrderManagement />;
      case "5":
        return <PromotionManagement />;
      case "6":
        return <AccountManagement />;
      case "7":
        return <></>;
      default:
        return <div>No Content</div>;
    }
  };

  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider
        collapsible
        collapsed={collapsed}
        onCollapse={(value) => setCollapsed(value)}
      >
        <div className="demo-logo-vertical" />
        <Menu
          theme="dark"
          defaultSelectedKeys={["1"]}
          mode="inline"
          items={items}
          onClick={handleMenuClick}
        />
      </Sider>
      <Layout>
        <Header style={{ padding: 0, background: colorBgContainer }} />
        <Content style={{ margin: "0 16px", fontSize: "16px" }}>
          <div
            style={{
              padding: 24,
              minHeight: 360,
              background: colorBgContainer,
              borderRadius: borderRadiusLG,
            }}
          >
            {renderContent()}
          </div>
        </Content>
        <Footer style={{ textAlign: "center" }}>
          MAPTH ©{new Date().getFullYear()} Created by MAPTH UED
        </Footer>
      </Layout>
    </Layout>
  );
};

export default Admin;
