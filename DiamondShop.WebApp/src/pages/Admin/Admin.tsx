import React, { useState } from "react";
import {
  PieChartOutlined,
  AppstoreOutlined,
  CrownOutlined,
  ShoppingCartOutlined,
} from "@ant-design/icons";
import type { MenuProps } from "antd";
import { Layout, Menu, theme } from "antd";
import Dashboard from "./Dashboard";
import DiamondManagement from "./DiamondManagement";
import OrderManagement from "./OrderManagement";
import ProductManagement from "./ProductManagement";

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
  getItem("Diamond", "3", <CrownOutlined />),
  getItem("Order", "4", <ShoppingCartOutlined />),
];

const Admin: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const [selectedKey, setSelectedKey] = useState("1");
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  const handleMenuClick: MenuProps["onClick"] = (e) => {
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
