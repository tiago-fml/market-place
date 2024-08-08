package com.orderservice.dtos.orders

import com.orderservice.dtos.orderlines.OrderLineCreateDto
import java.util.UUID

class OrderCreateDto(
    val userId: UUID,
    val shippingAddress: String,
    val total: Double,
    val orderLines: List<OrderLineCreateDto> = listOf(),
)