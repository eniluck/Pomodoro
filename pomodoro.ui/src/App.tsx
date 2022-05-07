import React from 'react';
import 'antd/dist/antd.css';
import './App.css';
import { Button, Layout, Menu } from 'antd';
import {
  DesktopOutlined,
  PieChartOutlined,
  FileOutlined,
  TeamOutlined,
  UserOutlined,
} from '@ant-design/icons';

const { Header, Content, Footer, Sider } = Layout;

function getItem(label: string, key: string, icon?: any , children?: any) {
  return {
    key,
    icon,
    children,
    label,
  };
}

const items = [
  getItem('Option 1', '1', <PieChartOutlined />),
  getItem('Option 2', '2', <DesktopOutlined />),
  getItem('User', 'sub1', <UserOutlined />, [
    getItem('Tom', '3'),
    getItem('Bill', '4'),
    getItem('Alex', '5'),
  ]),
  getItem('Team', 'sub2', <TeamOutlined />, [
    getItem('Team 1', '6'),
    getItem('Team 2', '8'),
  ]),
  getItem('Files', '9', <FileOutlined />),
];

class App extends React.Component {
  state = {
    collapsed: false,
  };
  onCollapse = (collapsed : boolean) => {
    console.log(collapsed);
    this.setState({
      collapsed,
    });
  };

  render() {
    const { collapsed } = this.state;

    return (
      <Layout className='main-layout'>
        <Sider theme='light' 
          collapsible 
          collapsed={collapsed} 
          onCollapse={this.onCollapse}
        >
          {/*<div className="logo" />*/}
          <Menu
            theme="light"
            defaultSelectedKeys={['1']}
            mode="inline"
            items={items}
          />
        </Sider>
        <Layout className='site-layout'>
          {/* <Header theme="light">Приложение Pomodoro</Header> */}
          <Content>
            <Button type="primary">Кнопка</Button>
          </Content>
          <Footer>Footer</Footer>
        </Layout>
      </Layout>
    );
  }
}

export default App;
