package com.orderservice.models

import com.orderservice.dtos.orders.OrderDto
import com.orderservice.enums.OrderStatus
import jakarta.persistence.*
import java.time.LocalDateTime
import java.util.*

@Entity
@Table(name = "orders")
class Order(
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: UUID = UUID.randomUUID(),
    val userId: UUID,

    @Enumerated(EnumType.STRING)
    val status: OrderStatus = OrderStatus.AWAITING_PAYMENT,
    
    val shippingAddress: String,
    val createdAt: LocalDateTime = LocalDateTime.now(),
    val total: Double,
    
    @OneToMany(mappedBy = "order", cascade = [(CascadeType.ALL)], orphanRemoval = true)
    var orderLines: List<OrderLine> = listOf(),
){
    fun toDto(): OrderDto {
        return OrderDto(
            id = this.id,
            userId = this.userId,
            status = this.status,
            shippingAddress = this.shippingAddress,
            createdAt = this.createdAt,
            total = this.total,
            orderLines = this.orderLines.map { it.toDto() }.toList()
        )
    }
}