import React, { useState, useEffect } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Button,
  Pagination,
  CircularProgress,
  ThemeProvider,
  createTheme,
} from "@mui/material";
import {
  fetchAccounts,
  deleteAccount,
  fetchAccountById,
  updateAccount,
  createAccount,
} from "./APIClient";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Empty } from "antd";
import AccountModal from "./Modal/AccountModal";
import { AuthAccount } from "../../types/account";

const theme = createTheme({
  typography: {
    fontSize: 15,
    htmlFontSize: 15,
  },
  components: {
    MuiTableCell: {
      styleOverrides: {
        root: {
          fontSize: "13px",
        },
      },
    },
  },
});

const AccountManagement: React.FC = () => {
  const [accounts, setAccounts] = useState<AuthAccount[]>([]);
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(10);
  const [totalAccounts, setTotalAccounts] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [sortColumn, setSortColumn] = useState<string>("");
  const [orderByDesc, setOrderByDesc] = useState<boolean>(true);
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [currentAccount, setCurrentAccount] =
    useState<Partial<AuthAccount> | null>(null);

  const fetchData = async () => {
    setLoading(true);
    try {
      const data = await fetchAccounts(
        search,
        page,
        rowsPerPage,
        sortColumn,
        orderByDesc
      );
      setAccounts(data.results);
      setTotalAccounts(data.totalCount);
    } catch (error) {
      console.error("Error fetching accounts:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    const timeoutId = setTimeout(() => {
      fetchData();
    }, 400);

    return () => clearTimeout(timeoutId);
  }, [page, rowsPerPage, search, sortColumn, orderByDesc]);

  useEffect(() => {
    setPage(1);
  }, []);

  const handleChangePage = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setPage(value);
  };

  const handleSort = (column: string) => {
    if (column === sortColumn) {
      setOrderByDesc((prev) => !prev);
    } else {
      setSortColumn(column);
      setOrderByDesc(true);
    }
  };

  const handleOpenModal = (account: Partial<AuthAccount> | null = null) => {
    setCurrentAccount(account);
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
    setCurrentAccount(null);
  };

  const handleSaveAccount = async (account: Partial<AuthAccount>) => {
    setModalOpen(false);
    await createAccount(account);
    setTotalAccounts(totalAccounts + 1);
    fetchData();
  };

  const handleDeleteAccount = async (accountId: string) => {
    try {
      await deleteAccount(accountId);
      setAccounts((prevAccounts) =>
        prevAccounts.filter((account) => account.id !== accountId)
      );
      setTotalAccounts(totalAccounts - 1);
    } catch (error) {
      console.error("Error deleting account:", error);
    }
  };

  return (
    <ThemeProvider theme={theme}>
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <input
          type="text"
          placeholder="Search..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          style={{
            width: "300px",
            padding: "10px",
            outline: "none",
            border: "none",
            borderBottom: "2px solid #FFD700",
          }}
        />
        <Button
          variant="contained"
          style={{ background: "#FFD700", fontSize: "10px" }}
          onClick={() => handleOpenModal()}
        >
          Add Account
        </Button>
      </div>

      {loading ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <CircularProgress style={{ color: "#FFD700" }} />
        </div>
      ) : accounts.length === 0 ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <Empty description="No Accounts Found" />
        </div>
      ) : (
        <TableContainer
          component={Paper}
          sx={{ borderRadius: "5px", marginTop: "10px", minHeight: "300px" }}
        >
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow sx={{ height: "25px" }}>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "30%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("email")}
                >
                  Email {sortColumn === "email" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("role")}
                >
                  Role {sortColumn === "role" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("status")}
                >
                  Status {sortColumn === "status" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "30%",
                  }}
                >
                  Customer Name
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                  }}
                >
                  Action
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {accounts.map((account) => (
                <TableRow
                  key={account.id}
                  sx={{ background: "rgb(243,247,251)" }}
                >
                  <TableCell sx={{ width: "30%" }}>{account.email}</TableCell>
                  <TableCell sx={{ width: "15%" }}>{account.role}</TableCell>
                  <TableCell sx={{ width: "15%" }}>{account.status}</TableCell>
                  <TableCell sx={{ width: "30%" }}>
                    {account.customer?.fullname
                      ? account.customer.fullname
                      : account.stakeHolder?.fullname}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    <IconButton
                      style={{ color: "orangered" }}
                      onClick={() => handleDeleteAccount(account.id)}
                    >
                      <DeleteIcon />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}
      <div
        style={{
          display: "flex",
          justifyContent: "flex-end",
          alignItems: "center",
          gap: "10px",
          marginTop: "20px",
        }}
      >
        <label>Rows Per Page:</label>
        <input
          value={rowsPerPage}
          onChange={(e) => setRowsPerPage(parseInt(e.target.value))}
          type="number"
          min={1}
          max={25}
          style={{ width: "50px", padding: "5px" }}
        />
      </div>
      <Pagination
        count={Math.ceil(totalAccounts / rowsPerPage)}
        page={page}
        onChange={handleChangePage}
        sx={{
          display: "flex",
          justifyContent: "center",
          "& .MuiPaginationItem-root.Mui-selected": {
            backgroundColor: "#FFD700",
            color: "white",
          },
        }}
      />
      <AccountModal
        open={modalOpen}
        handleClose={handleCloseModal}
        handleSave={handleSaveAccount}
        initialData={currentAccount || undefined}
        fetchAccountById={fetchAccountById}
      />
    </ThemeProvider>
  );
};

export default AccountManagement;
