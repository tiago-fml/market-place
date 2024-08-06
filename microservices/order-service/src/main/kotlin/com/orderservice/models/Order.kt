package com.orderservice.models

import com.orderservice.enums.OrderStatus
import jakarta.persistence.*
import java.time.LocalDateTime
import java.util.UUID

@Entity
@Table(name = "orders")
class Order(
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: UUID? = null,
    val userId: UUID,
    val status: OrderStatus = OrderStatus.AWAITING_PAYMENT,
    val shippingAddress: String,
    val createdAt: LocalDateTime = LocalDateTime.now(),
    val total: Double,
    
    @OneToMany(mappedBy = "order", cascade = [(CascadeType.ALL)])
    val orderLines: List<OrderLine> = listOf(),
)