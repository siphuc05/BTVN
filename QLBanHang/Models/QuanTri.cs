﻿using System;
using System.Collections.Generic;

namespace QLBanHang.Models;

public partial class QuanTri
{
    public int Id { get; set; }

    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public bool? TrangThai { get; set; }
}
